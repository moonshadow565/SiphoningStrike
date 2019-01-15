using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class RemoveItemReq : GamePacket // 0x009
    {
        public override GamePacketID ID => GamePacketID.RemoveItemReq;

        public byte Slot { get; set; }
        public bool Sell { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x7F);
            this.Sell = (bitfield & 0x80) != 0;

        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(this.Slot & 0x7F);
            if (Sell)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);

        }
    }
}