using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FaceDirection : GamePacket // 0x053
    {
        public override GamePacketID ID => GamePacketID.S2C_FaceDirection;

        public Vector3 Direction { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Direction = reader.ReadVector3();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(Direction);

        }
    }
}