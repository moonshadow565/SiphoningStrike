using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ToggleInputLockingFlag : GamePacket // 0x0A3
    {
        public override GamePacketID ID => GamePacketID.S2C_ToggleInputLockingFlag;

        public uint InputLockingFlags { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.InputLockingFlags = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.InputLockingFlags);
        }
    }
}