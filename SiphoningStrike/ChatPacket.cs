using System;
namespace SiphoningStrike
{
    public sealed class ChatPacket : BasePacket
    {
        public uint ClientID { get; set; }
        public uint ChatType { get; set; }
        public string Message { get; set; }

        public ChatPacket() {}
        public ChatPacket(byte[] data) { Read(data); }

        internal override void ReadPacket(ByteReader reader)
        {
            this.ClientID = reader.ReadUInt32();
            this.ChatType = reader.ReadUInt32();
            this.Message = reader.ReadSizedStringWithZero();
        }

        internal override void WritePacket(ByteWriter writer)
        {
            writer.WriteUInt32(this.ClientID);
            writer.WriteUInt32(this.ChatType);
            writer.WriteSizedStringWithZero(this.Message);
        }
    }
}
