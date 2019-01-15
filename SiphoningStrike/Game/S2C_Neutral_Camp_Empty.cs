using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_Neutral_Camp_Empty : GamePacket // 0x0CB
    {
        public override GamePacketID ID => GamePacketID.S2C_Neutral_Camp_Empty;

        public uint PlayerNetID { get; set; }
        public uint CampIndex { get; set; }
        public bool State { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.PlayerNetID = reader.ReadUInt32();
            this.CampIndex = reader.ReadUInt32();
            this.State = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.PlayerNetID);
            writer.WriteUInt32(this.CampIndex);
            writer.WriteBool(this.State);
        }
    }
}