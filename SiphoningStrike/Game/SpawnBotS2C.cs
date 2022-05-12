using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SpawnBotS2C : GamePacket // 0x0D8
    {
        public override GamePacketID ID => GamePacketID.S2C_SpawnBot;
        public uint UnitNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public byte BotRank { get; set; }
        public uint TeamID { get; set; }
        public uint SkinID { get; set; }
        public string Name { get; set; }
        public string SkinName { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.BotRank = reader.ReadByte();

            uint bitfield1 = reader.ReadUInt32();
            this.TeamID = (bitfield1 & 0x1FF);

            this.SkinID = reader.ReadUInt32();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteVector3(this.Position);
            writer.WriteByte(this.BotRank);

            uint bitfield1 = 0;
            bitfield1 |= (this.TeamID & 0x1FF);
            writer.WriteUInt32(bitfield1);

            writer.WriteUInt32(this.SkinID);
            writer.WriteFixedString(this.Name, 64);
            writer.WriteFixedString(this.SkinName, 64);
        }
    }
}