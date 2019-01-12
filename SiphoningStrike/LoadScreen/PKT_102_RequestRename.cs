using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.LoadScreen
{
    public class RequestRename : LoadScreenPacket
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.RequestRename;

        public ulong PlayerID { get; set; }
        public uint SkinID { get; set; }
        public string Name { get; set; }

        public RequestRename() { }
        public RequestRename(byte[] data)
        {
            var reader = new ByteReader(data);

            reader.ReadByte();

            this.PlayerID = reader.ReadUInt64();
            this.SkinID = reader.ReadUInt32();
            reader.ReadUInt32(); // buffer, length, ignored
            this.Name = reader.ReadFixedStringLast(128);

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();

            writer.WriteByte((byte)this.ID);

            writer.WriteByte((byte)this.ID);
            writer.WriteUInt64(this.PlayerID);
            writer.WriteUInt32(0); // buffer, length, ignored
            writer.WriteFixedStringLast(this.Name, 128);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}
