using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_StartGame : GamePacket // 0x05F
    {
        public override GamePacketID ID => GamePacketID.S2C_StartGame;

        public bool TournamentPauseEnabled { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            //FIXME: riot?
            if(reader.BytesLeft > 0)
            {
                byte bitfield = reader.ReadByte();
                this.TournamentPauseEnabled |= (bitfield & 1) != 0;
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (this.TournamentPauseEnabled)
                bitfield |= 1;
            writer.WriteByte(bitfield);
        }
    }
}