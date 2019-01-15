using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SynchVersionC2S : GamePacket // 0x0C5
    {
        public override GamePacketID ID => GamePacketID.SynchVersionC2S;

        public float TimeLastClient { get; set; }
        public uint ClientID { get; set; }
        public string VersionString { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TimeLastClient = reader.ReadFloat();
            this.ClientID = reader.ReadUInt32();
            this.VersionString = reader.ReadFixedStringLast(128);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.TimeLastClient);
            writer.WriteUInt32(this.ClientID);
            writer.WriteFixedStringLast(this.VersionString, 128);
        }
    }
}