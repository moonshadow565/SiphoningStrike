using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SpawnMinion : GamePacket // 0x080
    {
        public override GamePacketID ID => GamePacketID.S2C_SpawnMinion;

        public uint UnitNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public uint SkinID { get; set; }
        public uint CloneNetID { get; set; }
        public uint TeamID { get; set; }
        public float VisibilitySize { get; set; }
        public bool IgnoreCollision{ get; set; }
        public bool IsWard{ get; set; }
        public bool UseBehaviorTreeAI { get; set; }
        public string Name { get; set; }
        public string SkinName { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.SkinID = reader.ReadUInt32();
            this.CloneNetID = reader.ReadUInt32();

            uint bitfield1 = reader.ReadUInt32();
            this.TeamID = (bitfield1 & 0x1FF);

            this.VisibilitySize = reader.ReadFloat();

            byte bitfield2 = reader.ReadByte();
            this.IgnoreCollision = (bitfield2 & 0x01) != 0;
            this.IsWard = (bitfield2 & 0x02) != 0;
            this.UseBehaviorTreeAI = (bitfield2 & 0x04) != 0;

            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteVector3(this.Position);
            writer.WriteUInt32(this.SkinID);
            writer.WriteUInt32(this.CloneNetID);

            uint bitfield1 = 0;
            bitfield1 |= (this.TeamID & 0x1FFF);
            writer.WriteUInt32(bitfield1);

            writer.WriteFloat(this.VisibilitySize);

            byte bitfield2 = 0;
            if (this.IgnoreCollision)
                bitfield2 |= 0x01;
            if (this.IsWard)
                bitfield2 |= 0x02;
            if (this.UseBehaviorTreeAI)
                bitfield2 |= 0x04;
            writer.WriteByte(bitfield2);

            writer.WriteFixedString(this.Name, 64);
            writer.WriteFixedString(this.SkinName, 64);
        }
    }
}