using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsAlert : ArgsBase
    {
        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            reader.ReadPad(8);
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WritePad(8);
        }
    }
}
