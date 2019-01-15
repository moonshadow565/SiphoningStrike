using System;
namespace SiphoningStrike
{
    public abstract class GamePacket : BasePacket
    {
        public abstract GamePacketID ID { get; }
        public uint SenderNetID { get; set; }

        internal abstract void ReadBody(ByteReader reader);

        internal override void ReadPacket(ByteReader reader)
        {
            var id = (GamePacketID)reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();
            if(id == GamePacketID.ExtendedPacket)
            {
                reader.ReadUInt16();
            }

            ReadBody(reader);
        }

        internal abstract void WriteBody(ByteWriter writer);

        internal override void WritePacket(ByteWriter writer)
        {
            var id = (ushort)(this.ID);
            if (id > 0xFF)
            {
                writer.WriteByte(0xFE);
            }
            else
            {
                writer.WriteByte((byte)id);
            }
            writer.WriteUInt32(this.SenderNetID);
            if(id > 0xFF)
            {
                writer.WriteUInt16(id);
            }

            WriteBody(writer);
        }
    }
}
