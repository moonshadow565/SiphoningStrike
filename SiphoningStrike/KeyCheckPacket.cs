using System;
namespace SiphoningStrike
{
    public sealed class KeyCheckPacket : BasePacket
    {
        public byte Action { get; set; }
        public int ClientID { get; set; }
        public long PlayerID { get; set; }
        public ulong EncryptedPlayerID { get; set; }

        public KeyCheckPacket() {}
        public KeyCheckPacket(byte[] data)
        {
            var reader = new ByteReader(data);

            this.Action = reader.ReadByte();
            reader.ReadPad(3);
            this.ClientID = reader.ReadInt32();
            this.PlayerID = reader.ReadInt64();
            this.EncryptedPlayerID = reader.ReadUInt64();

            this.BytesLeft = reader.ReadBytesLeft();
        }

        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();

            writer.WriteByte(this.Action);
            writer.WritePad(3);
            writer.WriteInt32(this.ClientID);
            writer.WriteInt64(this.PlayerID);
            writer.WriteUInt64(this.EncryptedPlayerID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}