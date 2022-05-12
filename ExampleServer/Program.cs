using System;
using System.IO;
using System.Collections.Generic;
using LENet;
using SiphoningStrike;
using Newtonsoft.Json;
using System.Numerics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using SiphoningStrike.Game;
using SiphoningStrike.Game.Common;
using SiphoningStrike.LoadScreen;

namespace ExampleServer
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var address = new Address(Address.Any, 5119);
            var key = Encoding.ASCII.GetBytes("GLzvuWtyCfHyGhF2");
            var cids = new List<uint> { 1 };
            var server = new LeagueServer(address, key, cids);
            var mapNum = 1;
            var playerLiteInfo = new PlayerLoadInfo
            {
                PlayerID = 1,
                SummonorLevel = 30,
                TeamId = 0x64,
                SummonorSpell1 = 0,
                SummonorSpell2 = 0,
            };
            var skinID = 0u;
            var championName = "Nasus";
            var playerName = "Test";
            var jSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            var commandsList = new List<KeyValuePair<Regex, MethodInfo>>();
            foreach(var method in typeof(Commands).GetMethods(BindingFlags.Static | BindingFlags.Public))
            {
                var regex = new Regex(@"\." + method.Name + @"((?:\s(?:.*)|))?", RegexOptions.IgnoreCase);
                commandsList.Add(new KeyValuePair<Regex, MethodInfo>(regex, method));
            }


            server.OnPacket += (s, e) =>
            {
                var packet = e.Packet;
                var cid = e.ClientID;
                var channel = e.ChannelID;
                //Console.WriteLine($"Recieving {e.Packet.GetType().Name} on {e.ChannelID.ToString()} from {(uint)cid}");
                if(packet is IUnusedPacket)
                {
                    
                }
                else if (packet is C2S_QueryStatusReq statusReq)
                {
                    var answer = new S2C_QueryStatusAns();
                    answer.IsOK = true;
                    server.SendEncrypted(cid, ChannelID.Broadcast, answer);
                }
                else if(packet is RequestJoinTeam reqJoinTeam)
                {
                    var answer2 = new TeamRosterUpdate();
                    answer2.TeamSizeOrder = 1;
                    answer2.OrderPlayerIDs[0] = cid;
                    answer2.CurrentTeamSizeOrder = 1;
                    server.SendEncrypted(cid, ChannelID.LoadingScreen, answer2);

                    var answer1 = new RequestReskin();
                    answer1.PlayerID = cid;
                    answer1.SkinID = skinID;
                    answer1.Name = championName;
                    server.SendEncrypted(cid, ChannelID.LoadingScreen, answer1);


                    var answer3 = new RequestRename();
                    answer3.PlayerID = cid;
                    answer3.SkinID = 0;
                    answer3.Name = playerName;
                    server.SendEncrypted(cid, ChannelID.LoadingScreen, answer3);
                }
                else if(packet is C2S_Ping_Load_Info reqPingLoadInfo)
                {
                    var answer = new S2C_Ping_Load_Info();
                    answer.ConnectionInfo = reqPingLoadInfo.ConnectionInfo;
                    answer.ConnectionInfo.PlayerID = cid;
                    server.SendEncrypted(cid, ChannelID.Broadcast, answer);
                }
                else if (packet is C2S_SynchVersion syncReq)
                {
                    var answer = new S2C_SynchVersion();
                    answer.IsVersionOK = true;
                    answer.VersionString = syncReq.VersionString;
                    answer.MapToLoad = mapNum;
                    answer.PlayerInfo[0] = playerLiteInfo;
                    answer.MapMode = "Automatic";
                    server.SendEncrypted(cid, ChannelID.Broadcast, answer);
                }
                else if(packet is C2S_CharSelected reqSelected)
                {
                    var startSpawn = new S2C_StartSpawn();
                    server.SendEncrypted(cid, ChannelID.Broadcast, startSpawn);

                    var spawnHero = new S2C_CreateHero();
                    spawnHero.ClientID = cid;
                    spawnHero.Name = playerName;
                    spawnHero.Skin = championName;
                    spawnHero.SkinID = 0;
                    spawnHero.NetNodeID = 0x40;
                    spawnHero.UnitNetID = 0x40000001;
                    spawnHero.TeamIsOrder = true;
                    spawnHero.SkillLevel = 1;
                    server.SendEncrypted(cid, ChannelID.Broadcast, spawnHero);

                    /*
                    var avatarInfo = new AvatarInfo_Server();
                    avatarInfo.SenderNetID = 0x40000001;
                    avatarInfo.SummonerIDs[0] = 0;
                    server.SendEncrypted(cid, ChannelID.Broadcast, avatarInfo);
                    */

                    var endSpawn = new S2C_EndSpawn();
                    server.SendEncrypted(cid, ChannelID.Broadcast, endSpawn);
                }
                else if(packet is C2S_ClientReady reqReady)
                {
                    var startGame = new S2C_StartGame();
                    startGame.TournamentPauseEnabled = true;
                    server.SendEncrypted(cid, ChannelID.Broadcast, startGame);

                    var entervision = new S2C_OnEnterVisiblityClient();
                    entervision.SenderNetID = 0x40000001;
                    entervision.MovementData = new MovementDataStop
                    {
                        SyncID = Environment.TickCount,
                        Position = new Vector2(26.0f, 280.0f),
                        Forward = new Vector2(26.0f, 280.0f)
                    };
                    server.SendEncrypted(cid, ChannelID.Broadcast, entervision);
                }
                else if(packet is C2S_World_SendCamera_Server reqCamerPosition)
                {
                    
                }
                else if(packet is C2S_World_LockCamera_Server reqLockCameraServer)
                {
                    
                }
                else if(packet is ChatPacket reqChat)
                {
                    foreach(var kvp in commandsList)
                    {
                        var match = kvp.Key.Match(reqChat.Message);
                        if(match.Groups.Count == 2)
                        {
                            object value = match.Groups[1].Value;
                            object result = kvp.Value.Invoke(null, new object[] {
                                s, e.ClientID, value 
                            });
                            if(result != null && result is string strResult)
                            {

                                var response = new ChatPacket();
                                response.Message = strResult;
                                response.ChatType = reqChat.ChatType;
                                response.ClientID = e.ClientID;
                                server.SendEncrypted(e.ClientID, ChannelID.Chat, response);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(JsonConvert.SerializeObject(e, jSettings));
                    if(packet is C2S_NPC_IssueOrderReq movReq && movReq.OrderType == 2)
                    {
                        var resWaypoints = new S2C_WaypointGroup();
                        resWaypoints.SenderNetID = 0x40000001;
                        resWaypoints.SyncID = Environment.TickCount;
                        resWaypoints.Movements.Add(movReq.MovementData);

                        server.SendEncrypted(e.ClientID, ChannelID.Broadcast, resWaypoints);
                    }
                }
            };
            server.OnBadPacket += (s, e) =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(e, jSettings));
            };
            server.OnConnected += (s, e) =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(e, jSettings));
            };
            server.OnDisconnected += (s, e) =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(e, jSettings));
            };
            while(true)
            {
                server.RunOnce();
            }
        }
    }
}
