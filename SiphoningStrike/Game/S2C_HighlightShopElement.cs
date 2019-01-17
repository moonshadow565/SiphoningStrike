using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HighlightShopElement : GamePacket // 0x0B6
    {
        public override GamePacketID ID => GamePacketID.S2C_HighlightShopElement;

        public byte ElementType { get; set; }
        public byte ElementNumber { get; set; }
        public byte ElementSubCategory { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ElementType = reader.ReadByte();
            this.ElementNumber = reader.ReadByte();
            this.ElementSubCategory = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.ElementType);
            writer.WriteByte(this.ElementNumber);
            writer.WriteByte(this.ElementSubCategory);
        }
    }
}