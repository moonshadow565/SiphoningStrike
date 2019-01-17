using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_Ping_Load_Info : GamePacket // 0x019
    {
        public override GamePacketID ID => GamePacketID.C2S_Ping_Load_Info;
        public ConnectionInfo ConnectionInfo { get; set; } = new ConnectionInfo();

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