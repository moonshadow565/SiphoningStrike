using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;
using SiphoningStrike.Game.Events;

namespace SiphoningStrike.Game
{
    public sealed class NPC_Die_EventHistroy : GamePacket // 0x024
    {
        public class EventData
        {
            public float TimeStamp { get; set; }
            public ushort Count { get; set; }
            public uint SourceNetID { get; set; }
            public BaseEvent Event { get; set; }
        }

        public override GamePacketID ID => GamePacketID.NPC_Die_EventHistroy;


        public uint KillerNetID { get; set; }
        public float TimeWindow { get; set; }
        public uint KillerEventSourceType { get; set; }
        public List<EventData> Events = new List<EventData>();

        internal override void ReadBody(ByteReader reader)
        {
            this.KillerNetID = reader.ReadUInt32();
            this.TimeWindow = reader.ReadFloat();

            int bitfield = reader.ReadInt32();
            this.KillerEventSourceType = (uint)((bitfield & 0x0F) << 28 >> 28);

            int bufferSize = reader.ReadInt32();
            int count = reader.ReadInt32();

            for (var i = 0; i < count; i++)
            {
                var edata = new EventData();
                edata.TimeStamp = reader.ReadFloat();
                edata.Count = reader.ReadUInt16();
                edata.Event = BaseEvent.Create(reader);
                this.Events.Add(edata);
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.KillerNetID);
            writer.WriteFloat(this.TimeWindow);

            uint bitfield = 0;
            bitfield |= (this.KillerEventSourceType & 0x0F);

            var buffer = new ByteWriter();
            foreach (var edata in this.Events)
            {
                buffer.WriteFloat(edata.TimeStamp);
                buffer.WriteUInt16(edata.Count);
                edata.Event.Write(buffer);
            }
            var bufferData = buffer.GetBytes();

            writer.WriteInt32(bufferData.Length);
            writer.WriteInt32(this.Events.Count());
            writer.WriteBytes(bufferData);
        }
    }
}