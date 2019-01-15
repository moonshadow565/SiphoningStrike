using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_QueryStatusAns : GamePacket // 0x08D
    {
        public override GamePacketID ID => GamePacketID.S2C_QueryStatusAns;

        public bool IsOK { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.IsOK = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.IsOK);
        }
    }
}