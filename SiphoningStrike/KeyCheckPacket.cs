using System;
namespace SiphoningStrike
{
    public sealed class KeyCheckPacket : BasePacket
    {
        public byte Action { get; set; }
        public int ClientID { get; set; }
        public long PlayerID { get; set; }
        public ulong EncryptedPlayerID { get; set; }

        internal override void ReadPacket(ByteReader reader)
        {
            this.Action = reader.ReadByte();
            reader.ReadPad(3);
            this.ClientID = reader.ReadInt32();
            this.PlayerID = reader.ReadInt64();
            this.EncryptedPlayerID = reader.ReadUInt64();
        }

        internal override void WritePacket(ByteWriter writer)
        {
            writer.WriteByte(this.Action);
            writer.WritePad(3);
            writer.WriteInt32(this.ClientID);
            writer.WriteInt64(this.PlayerID);
            writer.WriteUInt64(this.EncryptedPlayerID);
        }
    }
}