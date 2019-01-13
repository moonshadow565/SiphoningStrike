using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SetItem : GamePacket // 0x056
    {
        public override GamePacketID ID => GamePacketID.SetItem;

        public byte Slot { get; set; }
        public uint ItemID { get; set; }
        public byte ItemsInSlot { get; set; }
        public byte SpellCharges { get; set; }

        public SetItem() {}
        public SetItem(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Slot = reader.ReadByte();
            this.ItemID = reader.ReadUInt32();
            this.ItemsInSlot = reader.ReadByte();
            this.SpellCharges = reader.ReadByte();

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
            writer.WriteByte(this.SpellCharges);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}