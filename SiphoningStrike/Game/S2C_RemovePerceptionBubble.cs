using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_RemovePerceptionBubble : GamePacket // 0x038
    {
        public override GamePacketID ID => GamePacketID.S2C_RemovePerceptionBubble;

        public uint BubbleID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.BubbleID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.BubbleID);
        }
    }
}