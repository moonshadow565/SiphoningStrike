using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_TeamSurrenderCountDown : GamePacket // 0x016
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderCountDown;

        public float TimeRemaining { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TimeRemaining = reader.ReadFloat();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.TimeRemaining);

        }
    }
}