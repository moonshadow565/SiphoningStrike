using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UNK_Unused_0C : GamePacket, IUnusedPacket // 0x00C
    {
        public override GamePacketID ID => GamePacketID.UNK_Unused_0C;
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