using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Common
{
    public class BasicAttackData
    {
        public uint TargetNetID { get; set; }
        public float ExtraTime { get; set; }
        public uint MissileNextID { get; set; }
        public byte AttackSlot { get; set; }
        public BasicAttackData() {}

        internal BasicAttackData(ByteReader reader)
        {
            this.TargetNetID = reader.ReadUInt32();
            this.ExtraTime = (reader.ReadByte() - 128) / 100.0f;
            this.MissileNextID = reader.ReadUInt32();
            this.AttackSlot = reader.ReadByte();
        }

        internal void Write(ByteWriter writer)
        {
            writer.WriteUInt32(this.TargetNetID);
            writer.WriteByte((byte)((int)(this.ExtraTime * 100.0f) + 128));
            writer.WriteUInt32(this.MissileNextID);
            writer.WriteByte(this.AttackSlot);
        }
    }
}
