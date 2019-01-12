using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike
{
    public sealed class BatchGamePacket : BasePacket
    {
        public List<GamePacket> Packets { get; set; }

        public BatchGamePacket() { }

        public BatchGamePacket(byte[] data)
        {
            var reader = new ByteReader(data);

            reader.ReadByte();

            throw new NotImplementedException();

            this.BytesLeft = reader.ReadBytesLeft();
        }

        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();

            writer.WriteByte((byte)GamePacketID.Batch);

            throw new NotImplementedException();

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}
