using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_MessageToClient : GamePacket // 0x01B
    {
        public override GamePacketID ID => GamePacketID.NPC_MessageToClient;

        public uint TargetNetID { get; set; }
        public float BubbleDelay { get; set; }
        public int SlotNumber { get; set; }
        public bool IsError { get; set; }
        public byte ColorIndex { get; set; }
        public string Message { get; set; } = "";

        internal override void ReadBody(ByteReader reader)
        {
            this.TargetNetID = reader.ReadUInt32();
            this.BubbleDelay = reader.ReadFloat();
            this.SlotNumber = reader.ReadInt32();
            this.IsError = reader.ReadBool();
            this.ColorIndex = reader.ReadByte();
            this.Message = reader.ReadFixedStringLast(1024);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.TargetNetID);
            writer.WriteFloat(this.BubbleDelay);
            writer.WriteInt32(this.SlotNumber);
            writer.WriteBool(this.IsError);
            writer.WriteByte(this.ColorIndex);
            writer.WriteFixedStringLast(this.Message, 1024);
        }
    }
}