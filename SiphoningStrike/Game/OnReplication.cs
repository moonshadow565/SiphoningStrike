using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class OnReplication : GamePacket // 0x0CC
    {
        public override GamePacketID ID => GamePacketID.OnReplication;

        public int SyncID { get; set; }

        public List<ReplicationData> ReplicationData { get; set; } = new List<ReplicationData>();

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
            int count = reader.ReadByte();

            for (var i = 0; i < count; i++)
            {
                this.ReplicationData.Add(reader.ReadReplicationData());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(this.SyncID);
            int count = ReplicationData.Count;
            if (count > 0xFF)
            {
                throw new IOException("Too many replication data in list > 0xFF");
            }
            writer.WriteByte((byte)count);
            for (int i = 0; i < count; i++)
            {
                writer.WriteReplicationData(ReplicationData[i]);
            }
        }
    }
}