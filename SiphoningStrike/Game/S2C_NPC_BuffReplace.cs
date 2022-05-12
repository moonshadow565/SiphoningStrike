using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_NPC_BuffReplace : GamePacket // 0x032
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_BuffReplace;

        public byte BuffSlot { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public uint CasterNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.BuffSlot = reader.ReadByte();
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            this.CasterNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.BuffSlot);
            writer.WriteFloat(this.RunningTime);
            writer.WriteFloat(this.Duration);
            writer.WriteUInt32(this.CasterNetID);
        }
    }
}