using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_Reconnect : GamePacket // 0x0A4
    {
        public override GamePacketID ID => GamePacketID.C2S_Reconnect;

        public bool IsFullReconnect { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.IsFullReconnect = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.IsFullReconnect);
        }
    }
}