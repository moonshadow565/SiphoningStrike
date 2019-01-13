using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ResumePacket : GamePacket // 0x00A
    {
        public override GamePacketID ID => GamePacketID.ResumePacket;

        public uint ClientID { get; set; }
        public bool Delayed { get; set; }

        public ResumePacket() {}
        public ResumePacket(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.ClientID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.Delayed = (bitfield & 0x01) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.ClientID);

            byte bitfield = 0;
            if (Delayed)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}