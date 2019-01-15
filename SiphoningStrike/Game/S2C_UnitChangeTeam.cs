using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_UnitChangeTeam : GamePacket // 0x0E0
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitChangeTeam;

        public uint UnitNetID { get; set; }
        public uint TeamID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.TeamID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteUInt32(this.TeamID);
        }
    }
}