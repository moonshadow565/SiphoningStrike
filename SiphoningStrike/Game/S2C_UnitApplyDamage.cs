using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_UnitApplyDamage : GamePacket // 0x068
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitApplyDamage;

        public byte DamageResultType { get; set; }
        public bool HasAttackSound { get; set; }
        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }
        public float Damage { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.DamageResultType = (byte)(bitfield & 0x7F);
            this.HasAttackSound = (bitfield & 0x80) != 0;

            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
            this.Damage = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(bitfield & 0x7F);
            if (this.HasAttackSound)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(this.TargetNetID);
            writer.WriteUInt32(this.SourceNetID);
            writer.WriteFloat(this.Damage);
        }
    }
}