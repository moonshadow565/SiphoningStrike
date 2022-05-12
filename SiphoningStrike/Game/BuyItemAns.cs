using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class BuyItemAns : GamePacket // 0x072
    {
        public override GamePacketID ID => GamePacketID.S2C_BuyItemAns;

        public byte Slot { get; set; }
        public uint ItemID { get; set; }
        public byte ItemsInSlot { get; set; }
        public bool UseOnBought { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Slot = reader.ReadByte();
            this.ItemID = reader.ReadUInt32();
            this.ItemsInSlot = reader.ReadByte();
            this.UseOnBought = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.Slot);
            writer.WriteUInt32(this.ItemID);
            writer.WriteByte(this.ItemsInSlot);
            writer.WriteBool(this.UseOnBought);
        }
    }
}