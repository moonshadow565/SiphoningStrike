using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SynchSimTime : GamePacket // 0x0C9
    {
        public override GamePacketID ID => GamePacketID.S2C_SynchSimTime;

        public float SynchTime { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.SynchTime = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.SynchTime);
        }
    }
}