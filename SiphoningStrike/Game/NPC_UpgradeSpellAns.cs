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
        public override GamePacketID ID => GamePacketID.NPC_UpgradeSpellAns;

        public byte Slot { get; set; }
        public byte SpellLevel { get; set; }
        public byte SkillPoints { get; set; }

        public NPC_UpgradeSpellAns() {}
        public NPC_UpgradeSpellAns(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Slot = reader.ReadByte();
            this.SpellLevel = reader.ReadByte();
            this.SkillPoints = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.Slot);
            writer.WriteByte(this.SpellLevel);
            writer.WriteByte(this.SkillPoints);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}