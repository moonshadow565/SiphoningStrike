using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_TutorialAudioEventFinished : GamePacket // 0x005
    {
        public override GamePacketID ID => GamePacketID.C2S_TutorialAudioEventFinished;
        public uint AudioEventNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.AudioEventNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.AudioEventNetID);
        }
    }
}