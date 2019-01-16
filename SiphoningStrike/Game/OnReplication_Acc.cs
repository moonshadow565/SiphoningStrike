using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class OnReplication_Acc : GamePacket // 0x0B0
    {
        public override GamePacketID ID => GamePacketID.OnReplication_Acc;
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