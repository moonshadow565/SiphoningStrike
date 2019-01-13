using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SynchVersionS2C : GamePacket // 0x057
    {
        public override GamePacketID ID => GamePacketID.SynchVersionS2C;

        private PlayerLoadInfo[] _playerInfo = new PlayerLoadInfo[12];

        public bool IsVersionOK { get; set; }
        public int MapToLoad { get; set; }
        public PlayerLoadInfo[] PlayerInfo => _playerInfo;
        public string VersionString { get; set; }
        public string MapMode { get; set; }


        public SynchVersionS2C() {}
        public SynchVersionS2C(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.IsVersionOK = reader.ReadBool();
            this.MapToLoad = reader.ReadInt32();
            for (var i = 0; i < this.PlayerInfo.Length; i++)
            {
                this.PlayerInfo[i] = reader.ReadPlayerInfo();
            }
            this.VersionString = reader.ReadFixedString(256);
            this.MapMode = reader.ReadFixedStringLast(128);

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteBool(this.IsVersionOK);
            writer.WriteInt32(this.MapToLoad);
            for (var i = 0; i < this.PlayerInfo.Length; i++)
            {
                writer.WritePlayerInfo(this.PlayerInfo[i]);
            }
            writer.WriteFixedString(this.VersionString, 256);
            writer.WriteFixedStringLast(this.MapMode, 128);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}