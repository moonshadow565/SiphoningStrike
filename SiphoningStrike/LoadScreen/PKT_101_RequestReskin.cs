using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.LoadScreen
{
    public class RequestReskin : LoadScreenPacket
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.RequestReskin;

        public ulong PlayerID { get; set; }
        public uint SkinID { get; set; }
        public string Name { get; set; } = "";

        internal override void ReadBody(ByteReader reader)
        {
            reader.ReadPad(7);
            this.PlayerID = reader.ReadUInt64();
            this.SkinID = reader.ReadUInt32();
            this.Name = reader.ReadSizedStringWithZero();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WritePad(7);
            writer.WriteUInt64(this.PlayerID);
            writer.WriteUInt32(this.SkinID);
            writer.WriteSizedStringWithZero(this.Name);
        }
    }
}
