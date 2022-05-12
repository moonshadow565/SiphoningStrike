using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_AI_TargetHero : GamePacket // 0x0C8
    {
        public override GamePacketID ID => GamePacketID.S2C_AI_TargetHero;

        public uint TargetNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TargetNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.TargetNetID);
        }
    }
}