using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ChangeSlotSpellIcon : GamePacket // 0x036
    {
        public override GamePacketID ID => GamePacketID.ChangeSlotSpellIcon;

        public byte Slot { get; set; }
        public bool IsSummonerSpell { get; set; }
        public byte IconIndex { get; set; }

        public ChangeSlotSpellIcon() {}
        public ChangeSlotSpellIcon(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.Slot = (byte)(bitfield & 0x7F);
            this.IsSummonerSpell = (bitfield & 0x80) != 0;

            this.IconIndex = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            byte bitfield = 0;
            bitfield |= (byte)(this.Slot & 0x7F);
            if (this.IsSummonerSpell)
                bitfield |= 0x80;
            writer.WriteByte(bitfield);

            writer.WriteByte(this.IconIndex);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}