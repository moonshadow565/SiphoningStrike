using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_RemoveDebugCircle : GamePacket // 0x05B
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveDebugCircle;

        public int DebugID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.DebugID = reader.ReadInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(this.DebugID);
        }
    }
}