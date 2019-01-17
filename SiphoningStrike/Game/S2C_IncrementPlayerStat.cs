using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_IncrementPlayerStat : GamePacket // 0x0E3
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementPlayerStat;

        public uint PlayerNetID { get; set; }
        public byte StatEvent { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.PlayerNetID = reader.ReadUInt32();
            this.StatEvent = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.PlayerNetID);
            writer.WriteByte(this.StatEvent);
        }
    }
}