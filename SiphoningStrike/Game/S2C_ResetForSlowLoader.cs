using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ResetForSlowLoader : GamePacket // 0x042
    {
        public override GamePacketID ID => GamePacketID.S2C_ResetForSlowLoader;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}