using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ToggleUIHighlight : GamePacket // 0x052
    {
        public override GamePacketID ID => GamePacketID.S2C_ToggleUIHighlight;

        public byte ElementID { get; set; }
        public byte ElementType { get; set; }
        public byte ElementNumber { get; set; }
        public byte ElementSubCategory { get; set; }
        public bool Enabled { get; set; }

        public S2C_ToggleUIHighlight() {}
        public S2C_ToggleUIHighlight(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.ElementID = reader.ReadByte();
            this.ElementType = reader.ReadByte();
            this.ElementNumber = reader.ReadByte();
            this.ElementSubCategory = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.Enabled = (bitfield & 1) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.ElementID);
            writer.WriteByte(this.ElementType);
            writer.WriteByte(this.ElementNumber);
            writer.WriteByte(this.ElementSubCategory);
            byte bitfield = 0;
            if (this.Enabled)
                bitfield |= 1;
            writer.WriteByte(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}