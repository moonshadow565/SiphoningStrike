using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_RefreshAuxiliaryText : GamePacket // 0x0B9
    {
        public override GamePacketID ID => GamePacketID.S2C_RefreshAuxiliaryText;

        public string TextStringID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TextStringID = reader.ReadZeroTerminatedString();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteZeroTerminatedString(this.TextStringID);
        }
    }
}