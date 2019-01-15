using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Connected : GamePacket // 0x078
    {
        public override GamePacketID ID => GamePacketID.Connected;

        public uint ClientID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ClientID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.ClientID);
        }
    }
}