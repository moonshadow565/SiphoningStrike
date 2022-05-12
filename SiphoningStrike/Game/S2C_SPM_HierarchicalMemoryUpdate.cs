using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SPM_HierarchicalMemoryUpdate : GamePacket, IUnusedPacket // 0x051
    {
        public override GamePacketID ID => GamePacketID.S2C_SPM_HierarchicalMemoryUpdate;
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