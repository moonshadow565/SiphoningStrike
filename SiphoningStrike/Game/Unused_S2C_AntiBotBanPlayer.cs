using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Unused_S2C_AntiBotBanPlayer : GamePacket, IUnusedPacket // 0x0E9
    {
        public override GamePacketID ID => GamePacketID.Unused_S2C_AntiBotBanPlayer;
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