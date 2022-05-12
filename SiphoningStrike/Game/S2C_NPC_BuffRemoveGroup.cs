using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_NPC_BuffRemoveGroup : GamePacket // 0x09B
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_BuffRemoveGroup;
        public uint BuffNameHash { get; set; }
        public List<BuffRemoveGroupEntry> Entries { get; set; } = new List<BuffRemoveGroupEntry>();

        internal override void ReadBody(ByteReader reader)
        {
            this.BuffNameHash = reader.ReadUInt32();

            int numInGroup = reader.ReadByte();
            for (var i = 0; i < numInGroup; i++)
            {
                this.Entries.Add(reader.ReadBuffRemoveGroupEntry());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.BuffNameHash);

            int numInGroup = this.Entries.Count;
            if (numInGroup > 0xFF)
            {
                throw new IOException("Too many BuffAddGroupEntry entries!");
            }
            for (var i = 0; i < numInGroup; i++)
            {
                writer.WriteBuffRemoveGroupEntry(this.Entries[i]);
            }
        }
    }
}