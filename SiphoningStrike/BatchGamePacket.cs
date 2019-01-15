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

        internal override void ReadPacket(ByteReader reader)
        {
            reader.ReadByte();
            throw new NotImplementedException();
        }

        internal override void WritePacket(ByteWriter writer)
        {
            writer.WriteByte((byte)GamePacketID.Batch);
            throw new NotImplementedException();
        }
    }
}
