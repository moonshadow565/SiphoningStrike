using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsBuff : ArgsBase
    {
        public uint EventSource { get; set; }
        public uint SourceScriptNameHash { get; set; }
        public uint SourceSpellLevel { get; set; }
        public uint ParentEventSource { get; set; }
        public uint ParentScriptNameHash { get; set; }
        public uint ParentCasterNetID { get; set; }

        public uint ParentTeam { get; set; }
        public uint ParentSourceType { get; set; }

        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.EventSource = reader.ReadUInt32();
            this.SourceScriptNameHash = reader.ReadUInt32();
            this.SourceSpellLevel = reader.ReadUInt32();
            this.ParentEventSource = reader.ReadUInt32();
            this.ParentScriptNameHash = reader.ReadUInt32();
            this.ParentCasterNetID = reader.ReadUInt32();

            int bitfield1 = reader.ReadInt32();
            this.ParentTeam = (uint)(bitfield1 & 0x0F);
            this.ParentSourceType = (uint)(((bitfield1 & 0xF0) >> 4) << 28 >> 28);
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteUInt32(this.EventSource);
            writer.WriteUInt32(this.SourceScriptNameHash);
            writer.WriteUInt32(this.SourceSpellLevel);
            writer.WriteUInt32(this.ParentEventSource);
            writer.WriteUInt32(this.ParentScriptNameHash);
            writer.WriteUInt32(this.ParentCasterNetID);

            uint bitfield1 = 0;
            bitfield1 |= (this.ParentTeam & 0x0F);
            bitfield1 |= (this.ParentSourceType & 0xF0) >> 4;
            writer.WriteUInt32(bitfield1);
        }
    }
}
