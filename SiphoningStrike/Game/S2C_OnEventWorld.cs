using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_OnEventWorld : GamePacket // 0x04A
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEventWorld;
        internal override void ReadBody(ByteReader reader)
        {
            // byte id
            // uint sourceNetID
            // params...
            throw new NotImplementedException();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}