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

        internal override void ReadBody(ByteReader reader)
        {
            reader.ReadPad(3);
            this.ClientID = reader.ReadUInt32();
            this.TeamID = reader.ReadUInt32();;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WritePad(3);
            writer.WriteUInt32(this.ClientID);
            writer.WriteUInt32(this.TeamID);
        }
    }
}
