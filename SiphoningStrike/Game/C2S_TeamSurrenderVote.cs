using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_TeamSurrenderVote : GamePacket // 0x0AC
    {
        public override GamePacketID ID => GamePacketID.C2S_TeamSurrenderVote;

        public bool VotedYes { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.VotedYes = (bitfield & 1) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (this.VotedYes)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}