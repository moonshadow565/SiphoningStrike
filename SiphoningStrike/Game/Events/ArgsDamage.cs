using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsDamage : ArgsBase
    {
        public float PhysicalDamage { get; set; }
        public float MagicalDamage { get; set; }
        public float TrueDamage { get; set; }
        public uint EventSource { get; set; }
        public uint SourceScriptNameHash { get; set; }
        public uint ParentScriptNameHash { get; set; }
        public uint ParentCasterNetID { get; set; }

        public uint ParentEventSource { get; set; }
        public uint ParentTeam { get; set; }
        public uint ParentSourceType { get; set; }
        public uint ParentSourceSpellLevel { get; set; }


        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.PhysicalDamage = reader.ReadFloat();
            this.MagicalDamage = reader.ReadFloat();
            this.TrueDamage = reader.ReadFloat();
            this.EventSource = reader.ReadUInt32();
            this.SourceScriptNameHash = reader.ReadUInt32();
            this.ParentScriptNameHash = reader.ReadUInt32();
            this.ParentCasterNetID = reader.ReadUInt32();

            //NOTE: do we need to sign-extend?
            int bitfield1 = reader.ReadByte();
            this.ParentEventSource = (uint)((bitfield1 & 0x0F) << 28 >> 28);
            this.ParentTeam = (uint)(bitfield1 & 0xF0) >> 4;

            int bitfield2 = reader.ReadByte();
            this.ParentSourceType = (uint)((bitfield2 & 0x0F) << 28 >> 28);
            this.ParentSourceSpellLevel = (uint)(((bitfield2 & 0x70) >> 4) << 28 >> 28);

            reader.ReadPad(2);
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteFloat(this.PhysicalDamage);
            writer.WriteFloat(this.MagicalDamage);
            writer.WriteFloat(this.TrueDamage);
            writer.WriteUInt32(this.EventSource);
            writer.WriteUInt32(this.SourceScriptNameHash);
            writer.WriteUInt32(this.ParentScriptNameHash);
            writer.WriteUInt32(this.ParentCasterNetID);

            byte bitfield1 = 0;
            bitfield1 |= (byte)(this.ParentEventSource & 0x0F);
            bitfield1 |= (byte)((this.ParentTeam << 4) & 0xF0);
            writer.WriteByte(bitfield1);

            byte bitfield2 = 0;
            bitfield2 |= (byte)(this.ParentSourceType & 0x0F);
            bitfield2 |= (byte)((this.ParentSourceSpellLevel << 4) & 0x70);
            writer.WriteByte(bitfield2);

            writer.WritePad(2);
        }
    }
}
