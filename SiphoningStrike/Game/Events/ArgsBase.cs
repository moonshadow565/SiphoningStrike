using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsBase
    {
        public uint OtherNetID { get; set; }
        internal virtual void Read(ByteReader reader)
        {
            this.OtherNetID = reader.ReadUInt32();
        }
        internal virtual void Write(ByteWriter writer)
        {
            writer.WriteUInt32(this.OtherNetID);
        }
    }
}
