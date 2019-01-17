using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_AnimatedBuildingSetCurrentSkin : GamePacket // 0x077
    {
        public override GamePacketID ID => GamePacketID.S2C_AnimatedBuildingSetCurrentSkin;

        public byte TeamID { get; set; }
        public uint SkinID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.TeamID = reader.ReadByte();
            this.SkinID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.TeamID);
            writer.WriteUInt32(this.SkinID);
        }
    }
}