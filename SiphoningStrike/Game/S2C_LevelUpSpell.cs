using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_LevelUpSpell : GamePacket // 0x05E
    {
        public override GamePacketID ID => GamePacketID.S2C_LevelUpSpell;

        public uint SpellSlot { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.SpellSlot = reader.ReadUInt32();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.SpellSlot);

        }
    }
}