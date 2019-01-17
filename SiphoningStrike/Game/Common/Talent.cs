using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Common
{
    public class Talent
    {
        public uint Hash { get; set; }
        public byte Level { get; set; }
    }

    static class TalentExtension
    {
        public static Talent ReadTalent(this ByteReader reader)
        {
            var data = new Talent();
            data.Hash = reader.ReadUInt32();
            data.Level = reader.ReadByte();
            return data;
        }
        public static void WriteTalent(this ByteWriter writer, Talent data)
        {
            if (data == null)
            {
                data = new Talent();
            }
            writer.WriteUInt32(data.Hash);
            writer.WriteByte(data.Level);
        }
    }
}
