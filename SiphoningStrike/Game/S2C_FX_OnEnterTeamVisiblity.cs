using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FX_OnEnterTeamVisiblity : GamePacket // 0x0F0
    {
        public override GamePacketID ID => GamePacketID.S2C_FX_OnEnterTeamVisiblity;

        public uint UnitNetID { get; set; }

        public byte VisiblityTeam { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.VisiblityTeam = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.VisiblityTeam);
        }
    }
}