using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ChangePARColorOverride : GamePacket // 0x099
    {
        public override GamePacketID ID => GamePacketID.ChangePARColorOverride;

        public uint UnitNetID { get; set; }
        public bool Enabled { get; set; }
        public Color BarColor { get; set; }
        public Color FadeColor { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            //FIXME: variable with "Enabled" ?
            this.UnitNetID = reader.ReadUInt32();
            this.Enabled = reader.ReadBool();
            this.BarColor = reader.ReadColor();
            this.FadeColor = reader.ReadColor();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteBool(this.Enabled);
            writer.WriteColor(this.BarColor);
            writer.WriteColor(this.FadeColor);
        }
    }
}