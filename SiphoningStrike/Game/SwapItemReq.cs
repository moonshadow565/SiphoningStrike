using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SwapItemReq : GamePacket // 0x023
    {
        public override GamePacketID ID => GamePacketID.SwapItemReq;

        public byte Source { get; set; }
        public byte Destination { get; set; }

        public SwapItemReq() {}
        public SwapItemReq(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Source = reader.ReadByte();
            this.Destination = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.Source);
            writer.WriteByte(this.Destination);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}