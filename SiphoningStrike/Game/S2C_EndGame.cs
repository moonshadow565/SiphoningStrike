using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_EndGame : GamePacket // 0x0CE
    {
        public override GamePacketID ID => GamePacketID.S2C_EndGame;

        public bool IsTeamOrderWin { get; set; }
        public bool IsSurrender { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.IsTeamOrderWin = (bitfield & 0x01) != 0;
            this.IsSurrender = (bitfield & 0x02) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (this.IsTeamOrderWin)
                bitfield |= 0x01;
            if (this.IsSurrender)
                bitfield |= 0x02;
            writer.WriteByte(bitfield);
        }
    }
}