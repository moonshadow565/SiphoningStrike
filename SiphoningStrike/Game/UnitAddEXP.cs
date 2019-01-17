using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UnitAddEXP : GamePacket // 0x011
    {
        public override GamePacketID ID => GamePacketID.UnitAddEXP;
        public uint TargetNetID { get; set; }
        public float ExpAmmount { get; set; }


        internal override void ReadBody(ByteReader reader)
        {
            this.TargetNetID = reader.ReadUInt32();
            this.ExpAmmount = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.TargetNetID);
            writer.WriteFloat(this.ExpAmmount);
        }
    }
}