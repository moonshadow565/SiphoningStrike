using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Turret_Fire : GamePacket // 0x09C
    {
        public override GamePacketID ID => GamePacketID.Turret_Fire;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}