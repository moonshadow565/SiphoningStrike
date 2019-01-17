using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsCapturePoint : ArgsBase
    {
        public uint CapturePoint { get; set; }
        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.CapturePoint = reader.ReadUInt32();
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteUInt32(this.CapturePoint);
        }
    }
}
