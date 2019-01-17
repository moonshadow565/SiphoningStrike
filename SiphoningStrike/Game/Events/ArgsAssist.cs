using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsAssist : ArgsBase
    {
        public float AtTime { get; set; }
        public float PhysicalDamage { get; set; }
        public float MagicalDamage { get; set; }
        public float TrueDamage { get; set; }
        public float PercentageOfAssist { get; set; }
        public float OriginalGoldReward { get; set; }
        public uint KillerNetID { get; set; }

        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.AtTime = reader.ReadFloat();
            this.PhysicalDamage = reader.ReadFloat();
            this.MagicalDamage = reader.ReadFloat();
            this.TrueDamage = reader.ReadFloat();
            this.PercentageOfAssist = reader.ReadFloat();
            this.OriginalGoldReward = reader.ReadFloat();
            this.KillerNetID = reader.ReadUInt32();
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteFloat(this.AtTime);
            writer.WriteFloat(this.PhysicalDamage);
            writer.WriteFloat(this.MagicalDamage);
            writer.WriteFloat(this.TrueDamage);
            writer.WriteFloat(this.PercentageOfAssist);
            writer.WriteFloat(this.OriginalGoldReward);
            writer.WriteUInt32(this.KillerNetID);
        }
    }
}
