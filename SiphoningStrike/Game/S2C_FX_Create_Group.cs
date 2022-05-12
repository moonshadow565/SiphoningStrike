using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FX_Create_Group : GamePacket // 0x08C
    {
        public override GamePacketID ID => GamePacketID.S2C_FX_Create_Group;

        public List<FXCreateGroupEntry> Entries { get; set; } = new List<FXCreateGroupEntry>();

        internal override void ReadBody(ByteReader reader)
        {
            int count = reader.ReadByte();
            for (var i = 0; i < count; i++)
            {
                this.Entries.Add(reader.ReadFXCreateGroupEntry());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            int count = Entries.Count;
            if(count  > 0xFF)
            {
                throw new IOException("Too many FXCreateGroupEntry!");
            }
            for (var i = 0; i < count; i++)
            {
                writer.WriteFXCreateGroupEntry(this.Entries[i]);
            }
        }
    }
}