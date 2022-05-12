using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SynchVersion : GamePacket // 0x057
    {
        public override GamePacketID ID => GamePacketID.S2C_SynchVersion;

        private PlayerLoadInfo[] _playerInfo = new PlayerLoadInfo[12];

        public bool IsVersionOK { get; set; }
        public int MapToLoad { get; set; }
        public PlayerLoadInfo[] PlayerInfo => _playerInfo;
        public string VersionString { get; set; } = "";
        public string MapMode { get; set; } = "";


        internal override void ReadBody(ByteReader reader)
        {
            this.IsVersionOK = reader.ReadBool();
            this.MapToLoad = reader.ReadInt32();
            for (var i = 0; i < this.PlayerInfo.Length; i++)
            {
                this.PlayerInfo[i] = reader.ReadPlayerInfo();
            }
            this.VersionString = reader.ReadFixedString(256);
            this.MapMode = reader.ReadFixedString(128);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.IsVersionOK);
            writer.WriteInt32(this.MapToLoad);
            for (var i = 0; i < this.PlayerInfo.Length; i++)
            {
                writer.WritePlayerInfo(this.PlayerInfo[i]);
            }
            writer.WriteFixedString(this.VersionString, 256);
            writer.WriteFixedString(this.MapMode, 128);
        }
    }
}