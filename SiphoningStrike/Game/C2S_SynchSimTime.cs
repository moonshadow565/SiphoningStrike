using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_SynchSimTime : GamePacket // 0x008
    {
        public override GamePacketID ID => GamePacketID.C2S_SynchSimTime;
        public uint ClientID { get; set; }
        public float TimeLastServer { get; set; }
        public float TimeLastClient { get; set; }
        public ulong ChecksumLO { get; set; }
        public ulong ChecksumHI { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ClientID = reader.ReadUInt32();
            this.TimeLastServer = reader.ReadFloat();
            this.TimeLastClient = reader.ReadFloat();
            this.ChecksumLO = reader.ReadUInt64();
            this.ChecksumHI = reader.ReadUInt64();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.ClientID);
            writer.WriteFloat(this.TimeLastServer);
            writer.WriteFloat(this.TimeLastClient);
            writer.WriteUInt64(this.ChecksumLO);
            writer.WriteUInt64(this.ChecksumHI);
        }
    }
}