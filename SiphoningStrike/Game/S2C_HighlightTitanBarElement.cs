using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HighlightTitanBarElement : GamePacket // 0x014
    {
        public override GamePacketID ID => GamePacketID.S2C_HighlightTitanBarElement;
        public byte ElementType { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ElementType = reader.ReadByte();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.ElementType);

        }
    }
}