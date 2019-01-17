using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HandleQuestUpdate : GamePacket // 0x090
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleQuestUpdate;

        public string Objective { get; set; } = "";
        public string Tooltip { get; set; } = "";
        public string Reward { get; set; } = "";
        public byte QuestType { get; set; }
        public byte Command { get; set; }

        public bool HandleRollovers { get; set; }

        public uint QuestID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Objective = reader.ReadFixedString(128);
            this.Tooltip = reader.ReadFixedString(128);
            this.Reward = reader.ReadFixedString(128);
            this.QuestType = reader.ReadByte();
            this.Command = reader.ReadByte();

            byte bitfield = reader.ReadByte();
            this.HandleRollovers = (bitfield & 0x01) != 0;

            this.QuestID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(this.Objective, 128);
            writer.WriteFixedString(this.Tooltip, 128);
            writer.WriteFixedString(this.Reward, 128);
            writer.WriteByte(this.QuestType);
            writer.WriteByte(this.Command);

            byte bitfield = 0;
            if (this.HandleRollovers)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteUInt32(this.QuestID);
        }
    }
}