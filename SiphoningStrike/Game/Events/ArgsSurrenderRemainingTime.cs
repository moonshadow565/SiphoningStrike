using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsSurrenderRemainingTime : ArgsBase
    {
        public float RemainingTime { get; set; }

        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.RemainingTime = reader.ReadFloat();
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteFloat(this.RemainingTime);
        }
    }
}
