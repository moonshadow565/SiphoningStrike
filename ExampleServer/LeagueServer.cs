using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ENet;
using SiphoningStrike;
using SiphoningStrike.Game;
using SiphoningStrike.Game.Common;
using SiphoningStrike.LoadScreen;

namespace ExampleServer
{
    public class LeagueDisconnectedEventArgs
    {
        public uint ClientID { get; private set; }
        public string EventName => "disconnected";
        public LeagueDisconnectedEventArgs(uint clientID)
        {
            ClientID = clientID;
        }
    }

    public class LeagueConnectedEventArgs
    {
        public uint ClientID { get; private set; }
        public string EventName => "connected";
        public LeagueConnectedEventArgs(uint clientID)
        {
            ClientID = clientID;
        }
    }

    public class LeaguePacketEventArgs : EventArgs
    {
        public string EventName => "packet";
        public uint ClientID { get; set; }
        public ChannelID ChannelID { get; private set; }
        public BasePacket Packet { get; private set; }
        public LeaguePacketEventArgs(uint clientID, ChannelID channel, BasePacket packet)
        {
            ClientID = clientID;
            ChannelID = channel;
            Packet = packet;
        }
    }

    public class LeagueBadPacketEventArgs : EventArgs
    {
        public string EventName => "badpacket";
        public uint ClientID { get; set; }
        public ChannelID ChannelID { get; private set; }
        public byte[] RawData { get; private set; }
        public Exception Exception { get; private set; }
        public LeagueBadPacketEventArgs(uint clientID, ChannelID channel, byte[] rawData, Exception exception)
        {
            ClientID = clientID;
            ChannelID = channel;
            RawData = rawData;
            Exception = exception;
        }
    }


    public static class ByteExtension 
    {
        public static void PrintHex(this byte[] data, int perline = 8)
        {
            for (int i = 0; i < data.Length; i += perline)
            {
                for (int c = i; c < (i + perline) && c < data.Length; c++)
                {
                    Console.Write("{0:X2} ", (uint)data[c]);
                }
                Console.Write("\r\n");
            }
        }
    }

    public static class PeerExtension
    {
        public static bool Send(this Peer peer, ChannelID channel, byte[] data,
                                bool reliable = true, bool unsequenced = false)
        {
            var packet = new ENet.Packet();
            var flags = PacketFlags.None;
            if(reliable)
            {
                flags |= PacketFlags.Reliable;
            }
            if(unsequenced)
            {
                flags |= PacketFlags.Unsequenced;
            }
            packet.Create(data, 0, data.Length, flags);
            return peer.Send((byte)channel, packet);
        }
    }


    public class LeagueServer
    {
        private Host _host;
        private BlowFish _blowfish;
        private Dictionary<uint, Peer> _peers = new Dictionary<uint, Peer>();
        public event EventHandler<LeagueDisconnectedEventArgs> OnDisconnected;
        public event EventHandler<LeagueConnectedEventArgs> OnConnected;
        public event EventHandler<LeaguePacketEventArgs> OnPacket;
        public event EventHandler<LeagueBadPacketEventArgs> OnBadPacket;

        public LeagueServer(Address address, byte[] key, List<uint> cids)
        {
            _host = new Host();
            _blowfish = new BlowFish(key);
            _host.Create(address,32, 8, 0, 0);
            foreach(var cid in cids)
            {
                _peers[cid] = null;
            }
        }

        private static void LogPacket(uint peerId, byte[] data, ChannelID channelID)
        {
            byte channel = (byte)channelID;
            byte packetId = data[0];
            int dataLength = data.Length;
            Console.Error.Write($"Log packet({packetId}) on({channel}) from({peerId}) size({dataLength})\n");
            for (var i = 0; i < dataLength; i += 16)
            {
                for (var c = i; c < dataLength && c < (i + 16); c++)
                    Console.Error.Write($"{(uint)(data[c]):X2} ");
                Console.Error.Write('\n');
            }
        }

        private bool SendEncrypted(Peer peer, ChannelID channel, BasePacket packet,
                                bool reliable = true, bool unsequenced = false)
        {
            var data = packet.GetBytes();
            /*
            var buffer = new byte[(data.Length / 8 + 1) * 8];
            Buffer.BlockCopy(data, 0, buffer, 0, data.Length);
            buffer = _blowfish.Encrypt(buffer);
            return peer.Send(channel, buffer, reliable, unsequenced);
            */
            data = _blowfish.Encrypt(data);
            return peer.Send(channel, data, reliable, unsequenced);
        }

        public bool SendEncrypted(uint client, ChannelID channel, BasePacket packet,
                                bool reliable = true, bool unsequenced = false)
        {
            if(!_peers.ContainsKey(client))
            {
                //TODO: throw here?
                return false;
            }
            var peer = _peers[client];
            if(peer == null)
            {
                //TODO: throw here?
                return false;
            }
            //LogPacket(client, packet.GetBytes(), channel);
            return SendEncrypted(_peers[client], channel, packet, reliable, unsequenced);
        }

        public void RunOnce()
        {
            while (_host.Service(0, out Event eevent) != 0)
            {
                switch (eevent.Type)
                {
                    case EventType.None:
                        break;
                    case EventType.Connect:
                        eevent.Peer.UserData = (IntPtr)0;
                        eevent.Peer.Mtu = 996;
                        break;
                    case EventType.Disconnect:
                        if((uint)eevent.Peer.UserData != 0)
                        {
                            var cid = (uint)eevent.Peer.UserData;
                            _peers[cid] = null;
                            OnDisconnected(this, new LeagueDisconnectedEventArgs(cid));
                        }
                        break;
                    case EventType.Receive:
                        if((uint)eevent.Peer.UserData == 0)
                        {
                            if(eevent.ChannelID != (byte)ChannelID.Default)
                            {
                                eevent.Peer.Disconnect(0);
                            }
                            else
                            {
                                HandleAuth(eevent.Peer, eevent.Packet);
                            }
                        }
                        else
                        {
                            HandlePacketParse((ChannelID)eevent.ChannelID, eevent.Peer, eevent.Packet);
                        }
                        break;
                }
            }
        }

        private void HandlePacketParse(ChannelID channel, Peer peer, Packet rawPacket)
        {
            var cid = (uint)peer.UserData;
            var rawData = rawPacket.GetBytes();
            rawData = _blowfish.Decrypt(rawData);
            try
            {
                var packet = BasePacket.Create(rawData, channel);
                OnPacket(this, new LeaguePacketEventArgs(cid, channel, packet));
            }
            catch (NotImplementedException exception)
            {
                OnBadPacket(this, new LeagueBadPacketEventArgs(cid, channel, rawData, exception));
            }
            catch (IOException exception)
            {
                OnBadPacket(this, new LeagueBadPacketEventArgs(cid, channel, rawData, exception));
            }
        }


        private void HandleAuth(Peer peer, Packet rawPacket)
        {
            var rawData = rawPacket.GetBytes();
            try
            {
                var clientAuthPacket = new KeyCheckPacket(rawData);
                Console.WriteLine($"Authing {clientAuthPacket.PlayerID} for {clientAuthPacket.ClientID}");
                if(_blowfish.Encrypt((ulong)clientAuthPacket.PlayerID) != clientAuthPacket.EncryptedPlayerID)
                {
                    Console.WriteLine($"Got bad checksum({clientAuthPacket.EncryptedPlayerID} for {clientAuthPacket.PlayerID})");
                    peer.Disconnect(0);
                    return;
                }
                var cid = (uint)clientAuthPacket.PlayerID;
                if(!_peers.ContainsKey(cid))
                {
                    Console.WriteLine($"Client id: {cid} not in allowed cid list!");
                    peer.Disconnect(0);
                    return;
                }
                if(_peers[cid] != null)
                {
                    Console.WriteLine($"Client already connected!");
                    peer.Disconnect(0);
                    return;
                }
                peer.UserData = (IntPtr)cid;
                _peers[cid] = peer;

                KeyCheckPacket serverAuthPacket = new KeyCheckPacket();
                serverAuthPacket.ClientID = cid;
                serverAuthPacket.PlayerID = cid;
                serverAuthPacket.EncryptedPlayerID = clientAuthPacket.EncryptedPlayerID;
                SendEncrypted(cid, ChannelID.Default, serverAuthPacket);
                OnConnected(this, new LeagueConnectedEventArgs(cid));
            }
            catch(IOException)
            {
                Console.WriteLine("Failed to read/write KeyCheck packet!");
                rawData.PrintHex();
                peer.Disconnect(0);
                return;
            }
        }
    }
}
