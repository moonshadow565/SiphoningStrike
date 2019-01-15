using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_CreateTurret : GamePacket // 0x0A5
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateTurret;

        public uint UniteNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public string Name { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UniteNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.Name = reader.ReadFixedStringLast(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UniteNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteFixedStringLast(this.Name, 64);
        }
    }
}