using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HandleGameScore : GamePacket // 0x0DD
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleGameScore;

        public uint TeamID { get; set; }
        public int Score { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TeamID = reader.ReadUInt32();
            this.Score = reader.ReadInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.TeamID);
            writer.WriteInt32(this.Score);
        }
    }
}