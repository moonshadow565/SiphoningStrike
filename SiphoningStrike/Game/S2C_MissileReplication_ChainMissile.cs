using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_MissileReplication_ChainMissile : GamePacket // 0x071
    {
        public override GamePacketID ID => GamePacketID.S2C_MissileReplication_ChainMissile;
        internal override void ReadBody(ByteReader reader)
        {
            // FIXME: read this (probably renamed to S2C_ForceCreateMissile later on)
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}