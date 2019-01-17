using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsKillingSpree : ArgsBase
    {
        public int Amount { get; set; }
        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.Amount = reader.ReadInt32();
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteInt32(this.Amount);
        }
    }
}
