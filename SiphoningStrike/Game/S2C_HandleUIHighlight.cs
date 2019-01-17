using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HandleUIHighlight : GamePacket // 0x0D3
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleUIHighlight;

        public byte UiHighlightCommand { get; set; }
        public byte UiElement { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UiHighlightCommand = reader.ReadByte();
            this.UiElement = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.UiHighlightCommand);
            writer.WriteByte(this.UiElement);
        }
    }
}