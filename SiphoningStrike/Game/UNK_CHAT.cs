using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UNK_CHAT : GamePacket // 0x092
    {
        public override GamePacketID ID => GamePacketID.UNK_CHAT;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}