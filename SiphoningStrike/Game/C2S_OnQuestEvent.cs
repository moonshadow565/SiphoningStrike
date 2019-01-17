using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_OnQuestEvent : GamePacket // 0x0D6
    {
        public override GamePacketID ID => GamePacketID.C2S_OnQuestEvent;

        public byte QuestEvent { get; set; }
        public uint QuestID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.QuestEvent = reader.ReadByte();
            this.QuestID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.QuestEvent);
            writer.WriteUInt32(this.QuestID);
        }
    }
}