using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UnitApplyHeal : GamePacket // 0x084
    {
        public override GamePacketID ID => GamePacketID.UnitApplyHeal;

        public float MaxHP { get; set; }
        public float Heal { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.MaxHP = reader.ReadFloat();
            this.Heal = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.MaxHP);
            writer.WriteFloat(this.Heal);
        }
    }
}