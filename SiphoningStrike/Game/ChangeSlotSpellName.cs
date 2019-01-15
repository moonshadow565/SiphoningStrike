using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ChangeSlotSpellName : GamePacket // 0x035
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellName;

        public byte Slot { get; set; }
        public bool IsSummonerSpell { get; set; }
        public string SpellName { get; set; } = "";

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x7F);
            this.IsSummonerSpell = (bitfield & 0x80) != 0;

            this.SpellName = reader.ReadFixedStringLast(64);

        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(this.Slot & 0x7F);
            if (this.IsSummonerSpell)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);

            writer.WriteFixedStringLast(this.SpellName, 64);

        }
    }
}