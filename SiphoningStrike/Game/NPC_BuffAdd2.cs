using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_BuffAdd2 : GamePacket // 0x0BF
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_BuffAdd2;

        public byte BuffSlot { get; set; }
        public byte ButtType { get; set; }
        public byte Count { get; set; }
        public bool IsHidden { get; set; }
        public uint BuffNameHash { get; set; }
        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public uint CasterNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.BuffSlot = reader.ReadByte();
            this.ButtType = reader.ReadByte();
            this.Count = reader.ReadByte();
            this.IsHidden = reader.ReadBool();
            this.BuffNameHash = reader.ReadUInt32();
            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            this.CasterNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.BuffSlot);
            writer.WriteByte(this.ButtType);
            writer.WriteByte(this.Count);
            writer.WriteBool(this.IsHidden);
            writer.WriteUInt32(this.BuffNameHash);
            writer.WriteFloat(this.RunningTime);
            writer.WriteFloat(this.Duration);
            writer.WriteUInt32(this.CasterNetID);
        }
    }
}