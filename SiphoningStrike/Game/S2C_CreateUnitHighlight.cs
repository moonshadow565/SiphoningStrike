using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_CreateUnitHighlight : GamePacket // 0x05C
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateUnitHighlight;

        public uint UnitNetID { get; set; }

        public S2C_CreateUnitHighlight() {}
        public S2C_CreateUnitHighlight(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.UnitNetID = reader.ReadUInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.UnitNetID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}