using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class WaypointGroup : GamePacket // 0x064
    {
        public override GamePacketID ID => GamePacketID.WaypointGroup;

        public int SyncID { get; set; }
        public List<MovementDataNormal> Movements { get; set; } = new List<MovementDataNormal>();

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
            int count = reader.ReadInt16();
            for (int i = 0; i < count; i++)
            {
                this.Movements.Add(new MovementDataNormal(reader, SyncID));
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