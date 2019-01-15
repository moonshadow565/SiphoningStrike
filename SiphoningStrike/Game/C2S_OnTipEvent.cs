using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_OnTipEvent : GamePacket // 0x070
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTipEvent;

        public byte TipCommand { get; set; }
        public uint TipID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TipCommand = reader.ReadByte();
            this.TipID = reader.ReadUInt32();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.TipCommand);
            writer.WriteUInt32(this.TipID);

        }
    }
}