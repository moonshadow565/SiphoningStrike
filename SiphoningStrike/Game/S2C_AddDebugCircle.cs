using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_AddDebugCircle : GamePacket // 0x0C3
    {
        public override GamePacketID ID => GamePacketID.S2C_AddDebugCircle;

        public uint DebugID { get; set; }
        public uint UnitNetID { get; set; }
        public Vector3 Center { get; set; }
        public float Radius { get; set; }
        public Color Color { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.DebugID = reader.ReadUInt32();
            this.UnitNetID = reader.ReadUInt32();
            this.Center = reader.ReadVector3();
            this.Radius = reader.ReadFloat();
            this.Color = reader.ReadColor();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.DebugID);
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteVector3(this.Center);
            writer.WriteFloat(this.Radius);
            writer.WriteColor(this.Color);
        }
    }
}