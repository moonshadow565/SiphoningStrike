using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FX_Kill : GamePacket // 0x03D
    {
        public override GamePacketID ID => GamePacketID.S2C_FX_Kill;

        public uint UnknownNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnknownNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnknownNetID);
        }
    }
}