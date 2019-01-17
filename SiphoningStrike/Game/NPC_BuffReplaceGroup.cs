using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_BuffReplaceGroup : GamePacket // 0x021
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffReplaceGroup;

        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public List<BuffReplaceGroupEntry> Entries = new List<BuffReplaceGroupEntry>();

        internal override void ReadBody(ByteReader reader)
        {
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();

            int numInGroup = reader.ReadByte();
            for (var i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffReplaceGroupEntry());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.RunningTime);
            writer.WriteFloat(this.Duration);

            int numInGroup = this.Entries.Count;
            if (numInGroup > 0xFF)
            {
                throw new IOException("Too many BuffReplaceGroupEntry entries!");
            }
            for (var i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffReplaceGroupEntry(this.Entries[i]);
            }
        }
    }
}