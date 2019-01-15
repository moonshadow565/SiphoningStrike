using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SwapItemAns : GamePacket // 0x044
    {
        public override GamePacketID ID => GamePacketID.SwapItemAns;

        public byte Source { get; set; }
        public byte Destination { get; set; }

        public SwapItemAns() {}

        public SwapItemAns(byte[] data)
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