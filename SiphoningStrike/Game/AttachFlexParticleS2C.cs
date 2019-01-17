using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class AttachFlexParticleS2C : GamePacket // 0x0DB
    {
        public override GamePacketID ID => GamePacketID.AttachFlexParticleS2C;

        public uint UnitNetID { get; set; }
        public byte FlexID { get; set; }
        public byte CpIndex { get; set; }
        public byte AttachType { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.FlexID = reader.ReadByte();
            this.CpIndex = reader.ReadByte();
            this.AttachType = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.FlexID);
            writer.WriteByte(this.CpIndex);
            writer.WriteByte(this.AttachType);
        }
    }
}