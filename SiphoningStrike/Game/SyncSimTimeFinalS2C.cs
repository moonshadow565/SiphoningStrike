using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SyncSimTimeFinalS2C : GamePacket // 0x079
    {
        public override GamePacketID ID => GamePacketID.S2C_SyncSimTimeFinal;

        public float TimeLastClient { get; set; }
        public float TimeRTTLastOverhead { get; set; }
        public float TimeConvergance { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TimeLastClient = reader.ReadFloat();
            this.TimeRTTLastOverhead = reader.ReadFloat();
            this.TimeConvergance = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.TimeLastClient);
            writer.WriteFloat(this.TimeRTTLastOverhead);
            writer.WriteFloat(this.TimeConvergance);
        }
    }
}