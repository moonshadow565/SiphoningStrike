using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FadeOutMainSFX : GamePacket // 0x062
    {
        public override GamePacketID ID => GamePacketID.S2C_FadeOutMainSFX;

        public float FadeTime { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.FadeTime = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.FadeTime);
        }
    }
}