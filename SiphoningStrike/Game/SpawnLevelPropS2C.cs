using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SpawnLevelPropS2C : GamePacket // 0x0D9
    {
        public override GamePacketID ID => GamePacketID.SpawnLevelPropS2C;

        public uint UniNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Facing { get; set; }
        public Vector3 PositionOffset { get; set; }
        public uint TeamID { get; set; }
        public byte SkillLevel { get; set; }
        public byte Rank { get; set; }
        public byte Type { get; set; }
        public string Name { get; set; }
        public string PropName { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UniNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.Facing = reader.ReadVector3();
            this.PositionOffset = reader.ReadVector3();

            uint bitfield1 = reader.ReadUInt32();
            this.TeamID = (bitfield1 & 0x1FF);

            this.SkillLevel = reader.ReadByte();
            this.Rank = reader.ReadByte();
            this.Type = reader.ReadByte();
            this.Name = reader.ReadFixedString(64);
            this.PropName = reader.ReadFixedString(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UniNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteVector3(this.Position);
            writer.WriteVector3(this.Facing);
            writer.WriteVector3(this.PositionOffset);

            uint bitfield1 = 0;
            bitfield1 |= (this.TeamID & 0x1FF);
            writer.WriteUInt32(bitfield1);

            writer.WriteByte(this.SkillLevel);
            writer.WriteByte(this.Rank);
            writer.WriteByte(this.Type);
            writer.WriteFixedString(this.Name, 64);
            writer.WriteFixedString(this.PropName, 64);
        }
    }
}