using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UnitAddGold : GamePacket // 0x025
    {
        public override GamePacketID ID => GamePacketID.S2C_UnitAddGold;

        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }
        public float GoldAmmount { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
            this.GoldAmmount = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.TargetNetID);
            writer.WriteUInt32(this.SourceNetID);
            writer.WriteFloat(this.GoldAmmount);
        }
    }
}