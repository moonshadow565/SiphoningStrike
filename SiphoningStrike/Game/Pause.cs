using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Pause : GamePacket // 0x033
    {
        public override GamePacketID ID => GamePacketID.S2C_Pause;

        public uint ClientID { get; set; }
        public int PauseTimeRemaining { get; set; }
        public bool IsTournamentPause { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ClientID = reader.ReadUInt32();
            this.PauseTimeRemaining = reader.ReadInt32();

            byte bitfield = reader.ReadByte();
            this.IsTournamentPause = (bitfield & 0x01) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.ClientID);
            writer.WriteInt32(this.PauseTimeRemaining);

            byte bitfield = 0;
            if (this.IsTournamentPause)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}