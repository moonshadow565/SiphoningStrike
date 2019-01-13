using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UnitApplyDamage : GamePacket // 0x068
    {
        public override GamePacketID ID => GamePacketID.UnitApplyDamage;

        public byte DamageResultType { get; set; }
        public bool HasAttackSound { get; set; }
        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }
        public float Damage { get; set; }

        public UnitApplyDamage() {}
        public UnitApplyDamage(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.DamageResultType = (byte)(bitfield & 0x7F);
            this.HasAttackSound = (bitfield & 0x80) != 0;

            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
            this.Damage = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            byte bitfield = 0;
            bitfield |= (byte)(bitfield & 0x7F);
            if (this.HasAttackSound)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(this.TargetNetID);
            writer.WriteUInt32(this.SourceNetID);
            writer.WriteFloat(this.Damage);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}