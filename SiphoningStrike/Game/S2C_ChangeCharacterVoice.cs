using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ChangeCharacterVoice : GamePacket // 0x09E
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeCharacterVoice;

        public bool IsReset { get; set; }
        public string VoiceOverride { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.IsReset = reader.ReadBool();
            this.VoiceOverride = reader.ReadZeroTerminatedString();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.IsReset);
            writer.WriteZeroTerminatedString(this.VoiceOverride);
        }
    }
}