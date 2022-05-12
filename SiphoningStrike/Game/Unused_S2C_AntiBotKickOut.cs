using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Unused_S2C_AntiBotKickOut : GamePacket, IUnusedPacket // 0x0E8
    {
        public override GamePacketID ID => GamePacketID.S2C_AntiBotKickOut;
        internal override void ReadBody(ByteReader reader)
        {
            //Unused
        }
        internal override void WriteBody(ByteWriter writer)
        {
            //Unused
        }
    }
}