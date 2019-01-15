using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class WaypointList : GamePacket // 0x0C1
    {
        public override GamePacketID ID => GamePacketID.WaypointList;

        public int SyncID { get; set; }
        public List<Vector2> Waypoints { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
            while(reader.BytesLeft != 0)
            {
                this.Waypoints.Add(reader.ReadVector2());
            }

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(this.SyncID);
            foreach(var waypoint in this.Waypoints)
            {
                writer.WriteVector2(waypoint);
            }
        }
    }
}