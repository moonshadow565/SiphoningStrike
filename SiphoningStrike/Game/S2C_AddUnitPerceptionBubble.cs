using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_AddUnitPerceptionBubble : GamePacket // 0x026
    {
        public override GamePacketID ID => GamePacketID.S2C_AddUnitPerceptionBubble;

        public uint PerceptionBubbleType { get; set; }
        public uint ClientNetID { get; set; }
        public float Radius { get; set; }
        public uint UnitNetID { get; set; }
        public float TimeToLive { get; set; }
        public uint BubbleID { get; set; }
        public uint Flags { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.PerceptionBubbleType = reader.ReadUInt32();
            this.ClientNetID = reader.ReadUInt32();
            this.Radius = reader.ReadFloat();
            this.UnitNetID = reader.ReadUInt32();
            this.TimeToLive = reader.ReadFloat();
            this.BubbleID = reader.ReadUInt32();
            this.Flags = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.PerceptionBubbleType);
            writer.WriteUInt32(this.ClientNetID);
            writer.WriteFloat(this.Radius);
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteFloat(this.TimeToLive);
            writer.WriteUInt32(this.BubbleID);
            writer.WriteUInt32(this.Flags);
        }
    }
}