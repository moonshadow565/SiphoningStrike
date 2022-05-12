using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Unused_SPM_HierarchicalProfilerUpdate : GamePacket, IUnusedPacket // 0x001
    {
        public override GamePacketID ID => GamePacketID.S2C_SPM_HierarchicalProfilerUpdate;
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