using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Unused_SPM_RemoveListener : GamePacket, IUnusedPacket // 0x08F
    {
        public override GamePacketID ID => GamePacketID.Unused_SPM_RemoveListener;
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