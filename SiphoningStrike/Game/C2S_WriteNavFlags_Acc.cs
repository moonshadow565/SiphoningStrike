using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_WriteNavFlags_Acc : GamePacket // 0x020
    {
        public override GamePacketID ID => GamePacketID.C2S_WriteNavFlags_Acc;

        public int SyncID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(this.SyncID);
        }
    }
}