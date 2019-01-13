using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HighlightHUDElement : GamePacket // 0x043
    {
        public override GamePacketID ID => GamePacketID.S2C_HighlightHUDElement;

        public byte ElementType { get; set; }
        public byte ElementNumber { get; set; }

        public S2C_HighlightHUDElement() {}
        public S2C_HighlightHUDElement(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.ElementType = reader.ReadByte();
            this.ElementNumber = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.ElementType);
            writer.WriteByte(this.ElementNumber);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}