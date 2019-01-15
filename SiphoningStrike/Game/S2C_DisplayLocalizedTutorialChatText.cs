using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_DisplayLocalizedTutorialChatText : GamePacket // 0x002
    {
        public override GamePacketID ID => GamePacketID.S2C_DisplayLocalizedTutorialChatText;

        public string Message { get; set; } = "";

        internal override void ReadBody(ByteReader reader)
        {
            this.Message = reader.ReadFixedStringLast(128);

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(this.Message, 128);

        }
    }
}