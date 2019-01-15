using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_CameraBehavior : GamePacket // 0x076
    {
        public override GamePacketID ID => GamePacketID.S2C_CameraBehavior;

        public Vector3 Position { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Position = reader.ReadVector3();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(this.Position);
        }
    }
}