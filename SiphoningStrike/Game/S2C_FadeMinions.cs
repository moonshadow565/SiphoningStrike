using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FadeMinions : GamePacket // 0x0D4
    {
        public override GamePacketID ID => GamePacketID.S2C_FadeMinions;

        public byte TeamID { get; set; }
        public float FadeAmount { get; set; }
        public float FadeTime { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TeamID = reader.ReadByte();
            this.FadeAmount = reader.ReadFloat();
            this.FadeTime = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.TeamID);
            writer.WriteFloat(this.FadeAmount);
            writer.WriteFloat(this.FadeTime);
        }
    }
}