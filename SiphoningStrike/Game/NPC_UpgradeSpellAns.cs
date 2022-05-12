using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_UpgradeSpellAns : GamePacket // 0x018
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_UpgradeSpellAns;

        public byte Slot { get; set; }
        public byte SpellLevel { get; set; }
        public byte SkillPoints { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Slot = reader.ReadByte();
            this.SpellLevel = reader.ReadByte();
            this.SkillPoints = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.Slot);
            writer.WriteByte(this.SpellLevel);
            writer.WriteByte(this.SkillPoints);
        }
    }
}