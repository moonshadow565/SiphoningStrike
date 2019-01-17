using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_UnitSetMinimapIcon : GamePacket // 0x0E1
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitSetMinimapIcon;

        public uint UnitNetID { get; set; }
        public string IconName { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.IconName = reader.ReadFixedString(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteFixedString(this.IconName, 64);
        }
    }
}