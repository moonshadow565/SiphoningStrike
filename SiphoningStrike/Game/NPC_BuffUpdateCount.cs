using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_BuffUpdateCount : GamePacket // 0x01F
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffUpdateCount;

        public byte BuffSlot { get; set; }
        public byte Count { get; set; }
        public float Duration { get; set; }
        public float RunningTime { get; set; }
        public uint CasterNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.BuffSlot = reader.ReadByte();
            this.Count = reader.ReadByte();
            this.Duration = reader.ReadFloat();
            this.RunningTime = reader.ReadFloat();
            this.CasterNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.BuffSlot);
            writer.WriteByte(this.Count);
            writer.WriteFloat(this.Duration);
            writer.WriteFloat(this.RunningTime);
            writer.WriteUInt32(this.CasterNetID);
        }
    }
}