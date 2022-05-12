using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_WaypointListHeroWithSpeed : GamePacket // 0x088
    {
        public override GamePacketID ID => GamePacketID.S2C_WaypointListHeroWithSpeed;

        public int SyncID { get; set; }
        public SpeedParams SpeedParams { get; set; } = new SpeedParams();
        public List<Vector2> Waypoints { get; set; } = new List<Vector2>();


        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
            this.SpeedParams = reader.ReadWaypointSpeedParams();
            while (reader.BytesLeft >= 8)
            {
                Vector2 waypoint = reader.ReadVector2();
                this.Waypoints.Add(waypoint);
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(SyncID);
            writer.WriteSpeedParams(SpeedParams);
            foreach (var waypoint in this.Waypoints)
            {
                writer.WriteVector2(waypoint);
            }
        }
    }
}