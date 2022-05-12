using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class DampenerSwitch : GamePacket // 0x02D
    {
        public override GamePacketID ID => GamePacketID.S2C_DampenerSwitch;

        public ushort Duration { get; set; }
        public bool State { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            ushort bitfield = reader.ReadUInt16();
            this.Duration = (ushort)(bitfield & 0x7FFF);

            byte bitfield2 = reader.ReadByte();
            this.State = (bitfield2 & 0x01) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            ushort bitfield = 0;
            bitfield |= (ushort)(this.Duration & 0x7FFF);
            writer.WriteUInt16(bitfield);

            byte bitfield2 = 0;
            if (this.State)
                bitfield2 |= 0x01;
            writer.WriteByte(bitfield2);
        }
    }
}