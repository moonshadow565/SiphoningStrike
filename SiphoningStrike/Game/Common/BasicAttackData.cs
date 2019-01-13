using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Common
{
    public class BasicAttackData
    {
        public uint TargetNetID { get; set; }
        public float ExtraTime { get; set; }
        public uint MissileNextID { get; set; }
        public byte AttackSlot { get; set; }
    }

    static class BasicAttackDataExtension
    {
        public static BasicAttackData ReadBasicAttackData(this ByteReader reader)
        {
            var data = new BasicAttackData();
            data.TargetNetID = reader.ReadUInt32();
            data.ExtraTime = (reader.ReadByte() - 128) / 100.0f;
            data.MissileNextID = reader.ReadUInt32();
            data.AttackSlot = reader.ReadByte();
            return data;
        }

        public static void WriteBasicAttackData(this ByteWriter writer, BasicAttackData data)
        {
            writer.WriteUInt32(data.TargetNetID);
            writer.WriteByte((byte)((int)(data.ExtraTime * 100.0f) + 128));
            writer.WriteUInt32(data.MissileNextID);
            writer.WriteByte(data.AttackSlot);
        }
    }
}
