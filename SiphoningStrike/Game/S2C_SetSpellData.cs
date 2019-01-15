using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetSpellData : GamePacket // 0x073
    {
        public override GamePacketID ID => GamePacketID.S2C_SetSpellData;

        public uint UnitNetID { get; set; }
        public uint SpellNameHash { get; set; }
        public byte SpellSlot { get; set; }

        public S2C_SetSpellData() {}
        public S2C_SetSpellData(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.UnitNetID = reader.ReadUInt32();
            this.SpellNameHash = reader.ReadUInt32();
            this.SpellSlot = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.UnitNetID);
            writer.WriteUInt32(this.SpellNameHash);
            writer.WriteByte(this.SpellSlot);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}