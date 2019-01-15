using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ModifyDebugCircleRadius : GamePacket // 0x02F
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugCircleRadius;

        public uint CircleID { get; set; }
        public float Radius { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.CircleID = reader.ReadUInt32();
            this.Radius = reader.ReadFloat();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.CircleID);
            writer.WriteFloat(this.Radius);

        }
    }
}