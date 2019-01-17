using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HeroStats : GamePacket // 0x04B
    {
        //FIXME: just ignore this useless packet?

        public override GamePacketID ID => GamePacketID.S2C_HeroStats;

        public byte[] Data { get; set; } = new byte[0];

        internal override void ReadBody(ByteReader reader)
        {
            int size = reader.ReadInt32();
            this.Data = reader.ReadBytes(size);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(Data.Length);
            writer.WriteBytes(Data);
        }

        public void WriteData(List<HeroStat> stats)
        {
            var writer = new ByteWriter();
            foreach (var stat in stats)
            {
                stat.Write(writer);
            }
            this.Data = writer.GetBytes();
        }

        public void ReadData(List<HeroStat> stats)
        {
            var reader = new ByteReader(this.Data);
            foreach (var stat in stats)
            {
                stat.Read(reader);
            }
        }
    }
}