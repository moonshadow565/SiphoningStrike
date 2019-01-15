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
        public override GamePacketID ID => GamePacketID.BuyItemAns;

        public byte Slot { get; set; }
        public uint ItemID { get; set; }
        public byte ItemsInSlot { get; set; }
        public bool UseOnBought { get; set; }

        public BuyItemAns() {}
        public BuyItemAns(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Slot = reader.ReadByte();
            this.ItemID = reader.ReadUInt32();
            this.ItemsInSlot = reader.ReadByte();
            this.UseOnBought = reader.ReadBool();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.Slot);
            writer.WriteUInt32(this.ItemID);
            writer.WriteByte(this.ItemsInSlot);
            writer.WriteBool(this.UseOnBought);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}