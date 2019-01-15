using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_TeamSurrenderStatus : GamePacket // 0x0AD
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderStatus;

        public uint Reason { get; set; }
        public byte ForVote { get; set; }
        public byte AgainstVote { get; set; }
        public uint TeamID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Reason = reader.ReadUInt32();
            this.ForVote = reader.ReadByte();
            this.AgainstVote = reader.ReadByte();
            this.TeamID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.Reason);
            writer.WriteByte(this.ForVote);
            writer.WriteByte(this.AgainstVote);
            writer.WriteUInt32(this.TeamID);
        }
    }
}