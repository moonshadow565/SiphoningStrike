using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_TeamSurrenderVote : GamePacket // 0x0D2
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderVote;

        public bool VoteYes { get; set; }
        public bool OpenVoteMenu { get; set; }

        public uint PlayerNetID { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public byte NumPlayers { get; set; }
        public uint TeamID { get; set; }
        public float TimeOut { get; set; }


        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.VoteYes = (bitfield & 1) != 0;
            this.OpenVoteMenu = (bitfield & 2) != 0;

            this.PlayerNetID = reader.ReadUInt32();
            this.ForVote = reader.ReadByte();
            this.AgainstVote = reader.ReadByte();
            this.NumPlayers = reader.ReadByte();
            this.TeamID = reader.ReadUInt32();
            this.TimeOut = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (this.VoteYes)
                bitfield |= 1;
            if (this.OpenVoteMenu)
                bitfield |= 2;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(this.PlayerNetID);
            writer.WriteByte(this.ForVote);
            writer.WriteByte(this.AgainstVote);
            writer.WriteByte(this.NumPlayers);
            writer.WriteUInt32(this.TeamID);
            writer.WriteFloat(this.TimeOut);
        }
    }
}