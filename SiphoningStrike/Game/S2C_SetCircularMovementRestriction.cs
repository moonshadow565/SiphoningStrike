using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetCircularMovementRestriction : GamePacket // 0x006
    {
        public override GamePacketID ID => GamePacketID.S2C_SetCircularMovementRestriction;
        public Vector3 Center { get; set; }
        public float Radius { get; set; }
        public bool RestrictCamera { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Center = reader.ReadVector3();
            this.Radius = reader.ReadFloat();
            this.RestrictCamera = reader.ReadBool();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(this.Center);
            writer.WriteFloat(this.Radius);
            writer.WriteBool(this.RestrictCamera);

        }
    }
}