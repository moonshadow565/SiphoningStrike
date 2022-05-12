using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_World_SendCamera_Server_Ack : GamePacket // 0x02E
    {
        public override GamePacketID ID => GamePacketID.S2C_World_SendCamera_Server_Ack;
        public SByte SyncID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadSByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteSByte(this.SyncID);
        }
    }
}