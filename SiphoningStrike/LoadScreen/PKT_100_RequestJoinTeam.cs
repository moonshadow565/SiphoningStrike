using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.LoadScreen
{
    public class RequestJoinTeam : LoadScreenPacket
    {
        public override LoadScreenPacketID ID => LoadScreenPacketID.RequestJoinTeam;
        public uint ClientID { get; set; }
        public uint TeamID { get; set; }

        public RequestJoinTeam() { }
        public RequestJoinTeam(byte[] data)
        {
            var reader = new ByteReader(data);

            reader.ReadByte();
            reader.ReadPad(3);

            this.ClientID = reader.ReadUInt32();
            this.TeamID = reader.ReadUInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();

            writer.WriteByte((byte)this.ID);
            writer.WritePad(3);

            writer.WriteUInt32(this.ClientID);
            writer.WriteUInt32(this.TeamID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}
