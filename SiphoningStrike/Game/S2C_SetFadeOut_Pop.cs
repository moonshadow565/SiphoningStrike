using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetFadeOut_Pop : GamePacket // 0x034
    {
        public override GamePacketID ID => GamePacketID.S2C_SetFadeOut_Pop;

        public short StackID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.StackID = reader.ReadInt16();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt16(this.StackID);
        }
    }
}