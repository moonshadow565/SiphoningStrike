using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ServerGameSettings : GamePacket // 0x095
    {
        public override GamePacketID ID => GamePacketID.S2C_ServerGameSettings;

        public bool FowLocalCulling { get; set; }
        public bool FowBroadcastEverything { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.FowLocalCulling = reader.ReadBool();
            this.FowBroadcastEverything = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.FowLocalCulling);
            writer.WriteBool(this.FowBroadcastEverything);
        }
    }
}