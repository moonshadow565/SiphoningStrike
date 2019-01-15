using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_PlayAnimation : GamePacket // 0x0B8
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayAnimation;

        public uint Flags { get; set; }
        public float ScaleTime { get; set; }
        public string AnimationName { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Flags = reader.ReadUInt32();
            this.ScaleTime = reader.ReadFloat();
            this.AnimationName = reader.ReadFixedStringLast(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.Flags);
            writer.WriteFloat(this.ScaleTime);
            writer.WriteFixedStringLast(this.AnimationName, 64);
        }
    }
}