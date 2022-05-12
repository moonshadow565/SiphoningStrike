using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_AI_Target : GamePacket // 0x06D
    {
        public override GamePacketID ID => GamePacketID.S2C_AI_Target;

        public uint TargetNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TargetNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(TargetNetID);
        }
    }
}