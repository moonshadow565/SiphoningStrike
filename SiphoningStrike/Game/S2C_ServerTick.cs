using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ServerTick : GamePacket // 0x02A
    {
        public override GamePacketID ID => GamePacketID.S2C_ServerTick;

        public float Delta { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Delta = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.Delta);
        }
    }
}