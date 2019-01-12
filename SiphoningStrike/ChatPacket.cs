using System;
namespace SiphoningStrike
{
    public sealed class ChatPacket : BasePacket
    {
        public uint ClientID { get; set; }
        public uint ChatType { get; set; }
        public string Message { get; set; }

        public ChatPacket() { }
        public ChatPacket(byte[] data)
        {
            var reader = new ByteReader(data);

            this.ClientID = reader.ReadUInt32();
            this.ChatType = reader.ReadUInt32();
            reader.ReadUInt32(); // buffer length, ignored
            this.Message = reader.ReadFixedStringLast(512);

            this.BytesLeft = reader.ReadBytesLeft();
        }

        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();

            writer.WriteUInt32(this.ClientID);
            writer.WriteUInt32(this.ChatType);
            writer.WriteUInt32(0); // buffer length, ignored
            writer.WriteFixedStringLast(this.Message, 512);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}
