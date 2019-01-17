using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_OpenTutorialPopup : GamePacket // 0x0BB
    {
        public override GamePacketID ID => GamePacketID.S2C_OpenTutorialPopup;

        public string MessageBoxStringID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.MessageBoxStringID = reader.ReadZeroTerminatedString();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteZeroTerminatedString(this.MessageBoxStringID);
        }
    }
}