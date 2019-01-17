using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsSurrenderVotes : ArgsBase
    {
        public int ForVote { get; set; }
        public int AgainstVote { get; set; }
        public uint TeamID { get; set; }

        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.ForVote = reader.ReadInt32();
            this.AgainstVote = reader.ReadInt32();
            this.TeamID = reader.ReadUInt32();
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteInt32(this.ForVote);
            writer.WriteInt32(this.AgainstVote);
            writer.WriteUInt32(this.TeamID);
        }
    }
}
