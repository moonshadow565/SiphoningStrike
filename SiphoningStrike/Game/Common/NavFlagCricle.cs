using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Common
{
    public class NavFlagCricle
    {
        public Vector2 Position { get; set; }
        public float Radius { get; set; }
        public uint Flags { get; set; }
    }

    static class NavFlagCircleExtension
    {
        public static NavFlagCricle ReadNavFlagCricle(this ByteReader reader)
        {
            var data = new NavFlagCricle();
            data.Position = reader.ReadVector2();
            data.Radius = reader.ReadFloat();
            data.Flags = reader.ReadUInt32();
            return data;
        }

        public static void WriteNavFlagCricle(this ByteWriter writer, NavFlagCricle data)
        {
            if (data == null)
            {
                data = new NavFlagCricle();
            }
            writer.WriteVector2(data.Position);
            writer.WriteFloat(data.Radius);
            writer.WriteUInt32(data.Flags);
        }
    }
}
