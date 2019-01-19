using System;
namespace SiphoningStrike
{
    public sealed class KeyCheckPacket : BasePacket
    {
        public byte Action { get; set; }
        public uint ClientID { get; set; }
        public ulong PlayerID { get; set; }
        public ulong EncryptedPlayerID { get; set; }

        public KeyCheckPacket() {}
        public KeyCheckPacket(byte[] data) { Read(data); }

        internal override void ReadPacket(ByteReader reader)
        {
            this.Action = reader.ReadByte();
            reader.ReadPad(3);
            this.ClientID = reader.ReadUInt32();
            this.PlayerID = reader.ReadUInt64();
            this.EncryptedPlayerID = reader.ReadUInt64();
        }

        internal override void WritePacket(ByteWriter writer)
        {
            writer.WriteByte(this.Action);
            writer.WritePad(3);
            writer.WriteUInt32(this.ClientID);
            writer.WriteUInt64(this.PlayerID);
            writer.WriteUInt64(this.EncryptedPlayerID);
        }
    }
}