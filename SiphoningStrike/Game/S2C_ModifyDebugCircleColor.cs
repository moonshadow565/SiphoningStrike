using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ModifyDebugCircleColor : GamePacket // 0x096
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugCircleColor;

        public uint ObjectID { get; set; }
        public Color Color { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ObjectID = reader.ReadUInt32();
            this.Color = reader.ReadColor();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.ObjectID);
            writer.WriteColor(this.Color);
        }
    }
}