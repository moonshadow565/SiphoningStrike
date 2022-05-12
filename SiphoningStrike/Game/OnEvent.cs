using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;
using SiphoningStrike.Game.Events;

namespace SiphoningStrike.Game
{
    public sealed class OnEvent : GamePacket // 0x0AB
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEvent;

        internal override void ReadBody(ByteReader reader)
        {
            // byte id
            // params...
            throw new NotImplementedException();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}