using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Common
{
    public class DeathData
    {
        public uint KillerNetID { get; set; }
        public byte DamageType { get; set; }
        public byte SpellSourceType { get; set; }
        public float DeathDuration { get; set; }
        public bool BecomeZombie { get; set; }
    }

    static class DeathDataPacketExtension
    {
        public static DeathData ReadDeathData(this ByteReader reader)
        {
            var data = new DeathData();
            data.KillerNetID = reader.ReadUInt32();
            data.DamageType = reader.ReadByte();
            data.SpellSourceType = reader.ReadByte();
            data.DeathDuration = reader.ReadFloat();
            data.BecomeZombie = reader.ReadBool();
            return data;
        }

        public static void WriteDeathData(this ByteWriter writer, DeathData data)
        {
            if (data == null)
            {
                data = new DeathData();
            }

            writer.WriteUInt32(data.KillerNetID);
            writer.WriteByte(data.DamageType);
            writer.WriteByte(data.SpellSourceType);
            writer.WriteFloat(data.DeathDuration);
            writer.WriteBool(data.BecomeZombie);
        }
    }
}
