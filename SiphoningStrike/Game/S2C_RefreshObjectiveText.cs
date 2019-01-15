using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_RefreshObjectiveText : GamePacket // 0x00E
    {
        public override GamePacketID ID => GamePacketID.S2C_RefreshObjectiveText;
        public string TextID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TextID = reader.ReadFixedStringLast(128);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedStringLast(TextID, 128);
        }
    }
}