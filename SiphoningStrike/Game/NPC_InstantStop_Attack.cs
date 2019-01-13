using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_InstantStop_Attack : GamePacket // 0x039
    {
        public override GamePacketID ID => GamePacketID.NPC_InstantStop_Attack;

        public bool KeepAnimating { get; set; }
        public bool ForceSpellCast { get; set; }
        public bool ForceStop { get; set; }
        public bool AvatarSpell { get; set; }
        public bool DestroyMissile { get; set; }

        public NPC_InstantStop_Attack() {}
        public NPC_InstantStop_Attack(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            byte bitfield = 0;
            this.KeepAnimating = (bitfield & 0x01) != 0;
            this.ForceSpellCast = (bitfield & 0x02) != 0;
            this.ForceStop = (bitfield & 0x04) != 0;
            this.AvatarSpell = (bitfield & 0x08) != 0;
            this.DestroyMissile = (bitfield & 0x10) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            byte bitfield = 0;
            if (this.KeepAnimating)
                bitfield |= 0x01;
            if (this.ForceSpellCast)
                bitfield |= 0x02;
            if (this.ForceStop)
                bitfield |= 0x04;
            if (this.AvatarSpell)
                bitfield |= 0x08;
            if (this.DestroyMissile)
                bitfield |= 0x10;
            writer.WriteByte(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}