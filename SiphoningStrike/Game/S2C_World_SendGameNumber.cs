using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_World_SendGameNumber : GamePacket // 0x098
    {
        public override GamePacketID ID => GamePacketID.S2C_World_SendGameNumber;

        public ulong GameID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.GameID = reader.ReadUInt64();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt64(this.GameID);
        }
    }
}