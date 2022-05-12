using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_WaypointGroupWithSpeed : GamePacket // 0x067
    {
        public override GamePacketID ID => GamePacketID.S2C_WaypointGroupWithSpeed;

        public int SyncID { get; set; }
        public List<MovementDataWithSpeed> Movements { get; set; } = new List<MovementDataWithSpeed>();
        public S2C_WaypointGroupWithSpeed() { }

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
            int count = reader.ReadInt16();
            for (int i = 0; i < count; i++)
            {
                this.Movements.Add(new MovementDataWithSpeed(reader, SyncID));
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            int count = Movements.Count;
            if (count > 0x7FFF)
            {
                throw new IOException("Too many movementdata!");
            }
            writer.WriteInt32(SyncID);
            writer.WriteInt16((short)count);
            foreach (var data in this.Movements)
            {
                data.Write(writer);
            }
        }
    }
}