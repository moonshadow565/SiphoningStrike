using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_Building_Die : GamePacket // 0x08E
    {
        public override GamePacketID ID => GamePacketID.S2C_Building_Die;

        public uint AttackerNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.AttackerNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.AttackerNetID);
        }
    }
}