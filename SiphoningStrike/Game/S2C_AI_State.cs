using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_AI_State : GamePacket // 0x0B3
    {
        public override GamePacketID ID => GamePacketID.S2C_AI_State;

        public uint AIState { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.AIState = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.AIState);
        }
    }
}