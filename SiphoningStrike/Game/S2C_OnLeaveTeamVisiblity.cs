using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_OnLeaveTeamVisiblity : GamePacket // 0x0EF
    {
        public override GamePacketID ID => GamePacketID.S2C_OnLeaveTeamVisiblity;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}