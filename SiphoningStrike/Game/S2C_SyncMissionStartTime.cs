using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SyncMissionStartTime : GamePacket // 0x0CA
    {
        public override GamePacketID ID => GamePacketID.S2C_SyncMissionStartTime;

        public float StartTime { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.StartTime = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.StartTime);
        }
    }
}