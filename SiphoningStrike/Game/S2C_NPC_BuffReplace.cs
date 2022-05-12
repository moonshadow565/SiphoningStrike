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

        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public byte NumInGroup { get; set; }
        public uint CasterNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            this.NumInGroup = reader.ReadByte();
            this.CasterNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(this.RunningTime);
            writer.WriteFloat(this.Duration);
            writer.WriteByte(this.NumInGroup);
            writer.WriteUInt32(this.CasterNetID);
        }
    }
}