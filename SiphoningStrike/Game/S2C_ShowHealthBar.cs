using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ShowHealthBar : GamePacket // 0x0D7
    {
        public override GamePacketID ID => GamePacketID.S2C_ShowHealthBar;

        public bool Show { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Show = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.Show);
        }
    }
}