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
        public string Name { get; set; } = "";

        internal override void ReadBody(ByteReader reader)
        {
            reader.ReadPad(7);
            this.PlayerID = reader.ReadUInt64();
            this.SkinID = reader.ReadUInt32();
            reader.ReadUInt32(); // buffer, length, ignored
            this.Name = reader.ReadFixedStringLast(128);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WritePad(7);
            writer.WriteUInt64(this.PlayerID);
            writer.WriteUInt32(this.SkinID);
            writer.WriteUInt32(0); // buffer, length, ignored
            writer.WriteFixedStringLast(this.Name, 128);
        }
    }
}
