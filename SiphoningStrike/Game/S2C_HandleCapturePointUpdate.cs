using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HandleCapturePointUpdate : GamePacket // 0x0DC
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleCapturePointUpdate;

        public byte CpIndex { get; set; }
        public uint OtherNetID { get; set; }
        public byte ParType { get; set; }
        public uint AttackTeam { get; set; }
        public byte Command { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.CpIndex = reader.ReadByte();
            this.OtherNetID = reader.ReadUInt32();
            this.ParType = reader.ReadByte();
            this.AttackTeam = reader.ReadUInt32();
            this.Command = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.CpIndex);
            writer.WriteUInt32(this.OtherNetID);
            writer.WriteByte(this.ParType);
            writer.WriteUInt32(this.AttackTeam);
            writer.WriteByte(this.Command);
        }
    }
}