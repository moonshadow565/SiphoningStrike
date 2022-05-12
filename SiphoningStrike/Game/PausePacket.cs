using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class PausePacket : GamePacket // 0x0A9
    {
        public override GamePacketID ID => GamePacketID.BID_PausePacket;

        public uint ClientID { get; set; }
        public int PauseTimeRemaining { get; set; }
        public bool TournamentPause { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ClientID = reader.ReadUInt32();
            this.PauseTimeRemaining = reader.ReadInt32();
            byte bitfield = reader.ReadByte();
            this.TournamentPause = (bitfield & 0x1) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(ClientID);
            writer.WriteInt32(PauseTimeRemaining);
            byte bitfield = 0;
            if (this.TournamentPause)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}