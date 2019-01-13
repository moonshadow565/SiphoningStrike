using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class AddUnitPerceptionBubble : GamePacket // 0x026
    {
        public override GamePacketID ID => GamePacketID.AddUnitPerceptionBubble;

        public uint PerceptionBubbleType { get; set; }
        public uint ClientNetID { get; set; }
        public float Radius { get; set; }
        public uint UnitNetID { get; set; }
        public float TimeToLive { get; set; }
        public uint Flags { get; set; }

        public AddUnitPerceptionBubble() {}
        public AddUnitPerceptionBubble(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.PerceptionBubbleType = reader.ReadUInt32();
            this.ClientNetID = reader.ReadUInt32();
            this.Radius = reader.ReadFloat();
            this.UnitNetID = reader.ReadUInt32();
            this.TimeToLive = reader.ReadFloat();
            this.Flags = reader.ReadUInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.PerceptionBubbleType);
            writer.WriteUInt32(this.ClientNetID);
            writer.WriteFloat(this.Radius);
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteFloat(this.TimeToLive);
            writer.WriteUInt32(this.Flags);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}