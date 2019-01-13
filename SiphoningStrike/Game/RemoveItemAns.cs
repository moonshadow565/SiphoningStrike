using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class RemoveItemAns : GamePacket // 0x00B
    {
        public override GamePacketID ID => GamePacketID.RemoveItemAns;

        public byte Slot { get; set; }
        public byte ItemsInSlot { get; set; }

        public RemoveItemAns() {}
        public RemoveItemAns(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Slot = reader.ReadByte();
            this.ItemsInSlot = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(Slot);
            writer.WriteByte(ItemsInSlot);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}