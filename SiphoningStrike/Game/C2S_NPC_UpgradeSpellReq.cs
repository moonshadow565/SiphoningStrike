using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_NPC_UpgradeSpellReq : GamePacket // 0x03E
    {
        public override GamePacketID ID => GamePacketID.C2S_NPC_UpgradeSpellReq;

        public byte Slot { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Slot = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.Slot);
        }
    }
}