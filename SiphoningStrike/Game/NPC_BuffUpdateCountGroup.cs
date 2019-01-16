using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_BuffUpdateCountGroup : GamePacket // 0x0C7
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateCountGroup;
        internal override void ReadBody(ByteReader reader)
        {
            throw new NotImplementedException();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}