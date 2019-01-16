using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ShowObjectiveText : GamePacket // 0x03B
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowObjectiveText;

        public string TextID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TextID = reader.ReadZeroTerminatedString();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteZeroTerminatedString(this.TextID);
        }
    }
}