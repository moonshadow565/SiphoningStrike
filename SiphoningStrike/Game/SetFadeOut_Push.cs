using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SetFadeOut_Push : GamePacket // 0x0BA
    {
        public override GamePacketID ID => GamePacketID.SetFadeOut_Push;

        public ushort FadeID { get; set; }
        public float FadeTime { get; set; }
        public float FadeTargetValue { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.FadeID = reader.ReadUInt16();
            this.FadeTime = reader.ReadFloat();
            this.FadeTargetValue = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt16(this.FadeID);
            writer.WriteFloat(this.FadeTime);
            writer.WriteFloat(this.FadeTargetValue);
        }
    }
}