using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ResumePacket : GamePacket // 0x00A
    {
        public override GamePacketID ID => GamePacketID.BID_ResumePacket;

        public uint ClientID { get; set; }
        public bool Delayed { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ClientID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.Delayed = (bitfield & 0x01) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.ClientID);

            byte bitfield = 0;
            if (Delayed)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}