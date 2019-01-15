using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_DisableHUDForEndOfGame : GamePacket // 0x0C4
    {
        public override GamePacketID ID => GamePacketID.S2C_DisableHUDForEndOfGame;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}