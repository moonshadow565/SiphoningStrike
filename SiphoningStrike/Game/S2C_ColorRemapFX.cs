using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ColorRemapFX : GamePacket // 0x0E4
    {
        public override GamePacketID ID => GamePacketID.S2C_ColorRemapFX;

        public bool IsFadingIn { get; set; }
        public float FadeTime { get; set; }
        public uint TeamID { get; set; }
        public Color Color { get; set; }
        public float MaxWeight { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.IsFadingIn = reader.ReadBool();
            this.FadeTime = reader.ReadFloat();
            this.TeamID = reader.ReadUInt32();
            this.Color = reader.ReadColor();
            this.MaxWeight = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.IsFadingIn);
            writer.WriteFloat(this.FadeTime);
            writer.WriteUInt32(this.TeamID);
            writer.WriteColor(this.Color);
            writer.WriteFloat(this.MaxWeight);
        }
    }
}