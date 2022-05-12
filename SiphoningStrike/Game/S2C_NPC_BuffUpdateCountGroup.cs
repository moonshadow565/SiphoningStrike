using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_NPC_BuffUpdateCountGroup : GamePacket // 0x0C7
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_BuffUpdateCountGroup;

        public float Duration { get; set; }
        public float RunningTime { get; set; }
        public List<BuffUpdateCountGroupEntry> Entries = new List<BuffUpdateCountGroupEntry>();

        internal override void ReadBody(ByteReader reader)
        {
            this.Duration = reader.ReadFloat();
            this.RunningTime = reader.ReadFloat();

            int numInGroup = reader.ReadByte();
            for (var i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffUpdateCountGroupEntry());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.Duration);
            writer.WriteFloat(this.RunningTime);

            int numInGroup = this.Entries.Count;
            if (numInGroup > 0xFF)
            {
                throw new IOException("Too many BuffUpdateCountGroupEntry entries!");
            }
            for (var i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffUpdateCountGroupEntry(this.Entries[i]);
            }
        }
    }
}