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

        internal override void ReadBody(ByteReader reader)
        {
            this.ElementType = reader.ReadByte();
            this.ElementNumber = reader.ReadByte();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.ElementType);
            writer.WriteByte(this.ElementNumber);

        }
    }
}