using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_CreateUnitHighlight : GamePacket // 0x05C
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateUnitHighlight;

        public uint UnitNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
        }
    }
}