using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_Ping_Load_Info : GamePacket // 0x09D
    {
        public override GamePacketID ID => GamePacketID.S2C_Ping_Load_Info;

        public ConnectionInfo ConnectionInfo { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ConnectionInfo = reader.ReadConnectionInfo();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteConnectionInfo(this.ConnectionInfo);
        }
    }
}