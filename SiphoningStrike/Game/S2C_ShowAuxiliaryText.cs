using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ShowAuxiliaryText : GamePacket // 0x0A8
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowAuxiliaryText;

        public string TextStringID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TextStringID = reader.ReadFixedString(128);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(this.TextStringID, 128);
        }
    }
}