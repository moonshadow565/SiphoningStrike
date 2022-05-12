using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_OnLeaveLocalVisiblityClient : GamePacket // 0x03A
    {
        public override GamePacketID ID => GamePacketID.S2C_OnLeaveLocalVisiblityClient;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}