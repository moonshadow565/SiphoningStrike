using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HandleTipUpdate : GamePacket // 0x058
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleTipUpdate;

        public string TipName { get; set; } = "";
        public string TipOther { get; set; } = "";
        public string TipImagePath { get; set; } = "";
        public byte TipCommand { get; set; }
        public uint TipID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TipName = reader.ReadFixedString(128);
            this.TipOther = reader.ReadFixedString(128);
            this.TipImagePath = reader.ReadFixedString(128);
            this.TipCommand = reader.ReadByte();
            this.TipID = reader.ReadUInt32();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(this.TipName, 128);
            writer.WriteFixedString(this.TipOther, 128);
            writer.WriteFixedString(this.TipImagePath, 128);
            writer.WriteByte(this.TipCommand);
            writer.WriteUInt32(this.TipID);

        }
    }
}