using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Waypoint_Acc : GamePacket // 0x07A
    {
        public override GamePacketID ID => GamePacketID.Waypoint_Acc;

        public int SyncID { get; set; }
        public byte TeleportCount { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
            this.TeleportCount = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(this.SyncID);
            writer.WriteByte(this.TeleportCount);
        }
    }
}