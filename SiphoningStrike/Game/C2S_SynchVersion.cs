using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_SynchVersion : GamePacket // 0x0C5
    {
        public override GamePacketID ID => GamePacketID.C2S_SynchVersion;

        public float TimeLastClient { get; set; }
        public uint ClientID { get; set; }
        public string VersionString { get; set; } = "";

        internal override void ReadBody(ByteReader reader)
        {
            this.TimeLastClient = reader.ReadFloat();
            this.ClientID = reader.ReadUInt32();
            this.VersionString = reader.ReadFixedString(128);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.TimeLastClient);
            writer.WriteUInt32(this.ClientID);
            writer.WriteFixedString(this.VersionString, 128);
        }
    }
}