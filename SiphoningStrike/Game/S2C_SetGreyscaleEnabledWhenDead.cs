using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetGreyscaleEnabledWhenDead : GamePacket // 0x0B2
    {
        public override GamePacketID ID => GamePacketID.S2C_SetGreyscaleEnabledWhenDead;

        public bool Enabled { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.Enabled = (bitfield & 0x01) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (this.Enabled)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}