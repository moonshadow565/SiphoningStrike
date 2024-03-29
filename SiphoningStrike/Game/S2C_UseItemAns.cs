using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_UseItemAns : GamePacket // 0x0A7
    {
        public override GamePacketID ID => GamePacketID.S2C_UseItemAns;

        public byte Slot { get; set; }
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Slot = reader.ReadByte();
            this.ItemsInSlot = reader.ReadByte();
            this.SpellCharges = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.Slot);
            writer.WriteByte(this.ItemsInSlot);
            writer.WriteByte(this.SpellCharges);
        }
    }
}