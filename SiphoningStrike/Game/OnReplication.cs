using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class OnReplication : GamePacket // 0x0CC
    {
        public override GamePacketID ID => GamePacketID.OnReplication;
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