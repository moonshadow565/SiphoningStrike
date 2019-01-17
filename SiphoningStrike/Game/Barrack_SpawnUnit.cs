using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Barrack_SpawnUnit : GamePacket // 0x003
    {
        public override GamePacketID ID => GamePacketID.Barrack_SpawnUnit;

        public uint UnitNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public byte WaveCount { get; set; }
        public byte MinionType { get; set; }
        public short DamageBonus { get; set; }
        public short HealthBonus { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.WaveCount = reader.ReadByte();
            this.MinionType = reader.ReadByte();
            this.DamageBonus = reader.ReadInt16();
            this.HealthBonus = reader.ReadInt16();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteByte(this.WaveCount);
            writer.WriteByte(this.MinionType);
            writer.WriteInt16(this.DamageBonus);
            writer.WriteInt16(this.HealthBonus);
        }
    }
}