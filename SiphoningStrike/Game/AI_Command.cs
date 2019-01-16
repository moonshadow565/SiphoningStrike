using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class AI_Command : GamePacket // 0x07E
    {
        public override GamePacketID ID => GamePacketID.AI_Command;

        public string Command { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Command = reader.ReadFixedString(128);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(this.Command, 128);
        }
    }
}