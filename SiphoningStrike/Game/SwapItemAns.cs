using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SwapItemAns : GamePacket // 0x044
    {
        public override GamePacketID ID => GamePacketID.SwapItemAns;

        public byte Source { get; set; }
        public byte Destination { get; set; }


        internal override void ReadBody(ByteReader reader)
        {
            this.Source = reader.ReadByte();
            this.Destination = reader.ReadByte();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.Source);
            writer.WriteByte(this.Destination);

        }
    }
}