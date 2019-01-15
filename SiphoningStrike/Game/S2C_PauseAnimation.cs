using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_PauseAnimation : GamePacket // 0x074
    {
        public override GamePacketID ID => GamePacketID.S2C_PauseAnimation;

        public bool Pause { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Pause = reader.ReadBool();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.Pause);

        }
    }
}