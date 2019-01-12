using System;
using System.Collections.Generic;

namespace SiphoningStrike
{
    public sealed class UnknownPacket : BasePacket
    {
        public UnknownPacket() { }
        public UnknownPacket(byte[] data)
        {
            var reader = new ByteReader(data);

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}
