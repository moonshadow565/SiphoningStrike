using System;
namespace SiphoningStrike
{
    public abstract class LoadScreenPacket : BasePacket
    {
        public abstract LoadScreenPacketID ID { get; }

        internal abstract void ReadBody(ByteReader reader);

        internal override void ReadPacket(ByteReader reader)
        {
            reader.ReadByte();
            ReadBody(reader);
        }

        internal abstract void WriteBody(ByteWriter writer);

        internal override void WritePacket(ByteWriter writer)
        {
            writer.WriteByte((byte)this.ID);
            WriteBody(writer);
        }
    }
}
