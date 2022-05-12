using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_BuyItemReq : GamePacket // 0x087
    {
        public override GamePacketID ID => GamePacketID.C2S_BuyItemReq;

        public uint ItemID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ItemID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.ItemID);
        }
    }
}