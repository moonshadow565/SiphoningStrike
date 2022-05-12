using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_BuffAddGroup : GamePacket // 0x06B
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_BuffAddGroup;

        public byte BuffType { get; set; }
        public uint BuffNameHash { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public List<BuffAddGroupEntry> Entries { get; set; } = new List<BuffAddGroupEntry>();


        internal override void ReadBody(ByteReader reader)
        {
            this.BuffType = reader.ReadByte();
            this.BuffNameHash = reader.ReadUInt32();
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();

            int numInGroup = reader.ReadByte();
            for (var i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffAddGroupEntry());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.BuffType);
            writer.WriteUInt32(this.BuffNameHash);
            writer.WriteFloat(this.RunningTime);
            writer.WriteFloat(this.Duration);

            int numInGroup = this.Entries.Count;
            if(numInGroup > 0xFF)
            {
                throw new IOException("Too many BuffAddGroupEntry entries!");
            }
            for (var i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffAddGoupEntry(this.Entries[i]);
            }
        }
    }
}