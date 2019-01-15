using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ReplayOnly_GoldEarned : GamePacket // 0x0F2
    {
        public override GamePacketID ID => GamePacketID.ReplayOnly_GoldEarned;

        public uint OwnerNetID { get; set; }
        public float Amount { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.OwnerNetID = reader.ReadUInt32();
            this.Amount = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.OwnerNetID);
            writer.WriteFloat(this.Amount);
        }
    }
}