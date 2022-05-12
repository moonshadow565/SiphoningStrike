using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_RemoveItemAns : GamePacket // 0x00B
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveItemAns;

        public byte Slot { get; set; }
        public byte ItemsInSlot { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Slot = reader.ReadByte();
            this.ItemsInSlot = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(Slot);
            writer.WriteByte(ItemsInSlot);
        }
    }
}