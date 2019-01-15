using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_Die : GamePacket // 0x0A6
    {
        public override GamePacketID ID => GamePacketID.NPC_Die;

        public uint KillerNetID { get; set; }
        public float TimeWindow { get; set; }
        public uint KillerEventSourceType { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.KillerNetID = reader.ReadUInt32();
            this.TimeWindow = reader.ReadFloat();

            uint bitfield = reader.ReadUInt32();
            this.KillerEventSourceType = (bitfield & 0x0F);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.KillerNetID);
            writer.WriteFloat(this.TimeWindow);

            uint bitfield = 0;
            bitfield |= (this.KillerEventSourceType & 0x0F);
            writer.WriteUInt32(bitfield);
        }
    }
}