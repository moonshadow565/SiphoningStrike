using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SynchSimTimeC2S : GamePacket // 0x008
    {
        public override GamePacketID ID => GamePacketID.SynchSimTimeC2S;
        public float TimeLastServer { get; set; }
        public float TimeLastClient { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TimeLastServer = reader.ReadFloat();
            this.TimeLastClient = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.TimeLastServer);
            writer.WriteFloat(this.TimeLastClient);
        }
    }
}