using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_LockCamera : GamePacket // 0x07C
    {
        public override GamePacketID ID => GamePacketID.S2C_LockCamera;

        public bool Lock { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Lock = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.Lock);
        }
    }
}