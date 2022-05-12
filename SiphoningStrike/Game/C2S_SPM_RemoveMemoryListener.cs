using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_SPM_RemoveMemoryListener : GamePacket, IUnusedPacket // 0x093
    {
        public override GamePacketID ID => GamePacketID.C2S_SPM_RemoveMemoryListener;
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