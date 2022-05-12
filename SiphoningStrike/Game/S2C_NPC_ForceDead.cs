using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_NPC_ForceDead : GamePacket // 0x01E
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_ForceDead;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}