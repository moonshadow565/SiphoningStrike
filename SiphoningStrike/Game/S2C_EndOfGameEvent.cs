using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_EndOfGameEvent : GamePacket // 0x0CD
    {
        public override GamePacketID ID => GamePacketID.S2C_EndOfGameEvent;

        public bool TeamIsOrder { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TeamIsOrder = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.TeamIsOrder);
        }
    }
}