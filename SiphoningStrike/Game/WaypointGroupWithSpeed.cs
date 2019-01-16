using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class WaypointGroupWithSpeed : GamePacket // 0x067
    {
        public override GamePacketID ID => GamePacketID.WaypointGroupWithSpeed;
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