using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SwitchNexusesToOnIdleParticles : GamePacket // 0x004
    {
        public override GamePacketID ID => GamePacketID.S2C_SwitchNexusesToOnIdleParticles;
        internal override void ReadBody(ByteReader reader)
        {
        }
        internal override void WriteBody(ByteWriter writer)
        {
        }
    }
}