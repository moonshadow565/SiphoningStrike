using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SetFrequency : GamePacket // 0x013
    {
        public override GamePacketID ID => GamePacketID.SetFrequency;
        public float NewFrequency { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.NewFrequency = reader.ReadFloat();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.NewFrequency);

        }
    }
}