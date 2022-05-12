using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_NPC_CastSpellAns : GamePacket // 0x0BD
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_CastSpellAns;

        public int CasterPositionSyncID { get; set; }
        public CastInfo CastInfo { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.CasterPositionSyncID = reader.ReadInt32();
            this.CastInfo = reader.ReadCastInfo();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(this.CasterPositionSyncID);
            writer.WriteCastInfo(this.CastInfo);
        }
    }
}