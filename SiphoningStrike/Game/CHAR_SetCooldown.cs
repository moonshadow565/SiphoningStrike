using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class CHAR_SetCooldown : GamePacket // 0x08A
    {
        public override GamePacketID ID => GamePacketID.CHAR_SetCooldown;

        public byte Slot { get; set; }
        public bool IsSummonerSpell { get; set; }
        public float Cooldown { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x7F);
            this.IsSummonerSpell = (bitfield & 0x80) != 0;

            this.Cooldown = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            bitfield |= (byte)(this.Slot & 0x7F);
            if (this.IsSummonerSpell)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);

            writer.WriteFloat(this.Cooldown);
        }
    }
}