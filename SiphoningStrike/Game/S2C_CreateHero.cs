using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_CreateHero : GamePacket // 0x04F
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateHero;

        public uint UnitNetID { get; set; }
        public uint ClientID { get; set; }
        public byte NetNodeID { get; set; }
        public byte SkillLevel { get; set; }
        public bool TeamIsOrder { get; set; }
        public bool IsBot { get; set; }
        public byte BotRank { get; set; }
        public byte SpawnPositionIndex { get; set; }
        public uint SkinID { get; set; }
        public string Name { get; set; } = "";
        public string Skin { get; set; } = "";

        public S2C_CreateHero() {}
        public S2C_CreateHero(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.UnitNetID = reader.ReadUInt32();
            this.ClientID = reader.ReadUInt32();
            this.NetNodeID = reader.ReadByte();
            this.SkillLevel = reader.ReadByte();
            this.TeamIsOrder = reader.ReadBool();
            this.IsBot = reader.ReadBool();
            this.BotRank = reader.ReadByte();
            this.SpawnPositionIndex = reader.ReadByte();
            this.SkinID = reader.ReadUInt32();
            this.Name = reader.ReadFixedString(40);
            this.Skin = reader.ReadFixedString(40);

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.UnitNetID);
            writer.WriteUInt32(this.ClientID);
            writer.WriteByte(this.NetNodeID);
            writer.WriteByte(this.SkillLevel);
            writer.WriteBool(this.TeamIsOrder);
            writer.WriteBool(this.IsBot);
            writer.WriteByte(this.BotRank);
            writer.WriteByte(this.SpawnPositionIndex);
            writer.WriteUInt32(this.SkinID);
            writer.WriteFixedString(this.Name, 40);
            writer.WriteFixedString(this.Skin, 40);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}