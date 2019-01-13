using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_BuffReplace : GamePacket // 0x032
    {
        public override GamePacketID ID => GamePacketID.NPC_BuffReplace;

        public float RunningTime { get; set; }
        public float Duration { get; set; }
        public byte NumInGroup { get; set; }

        public NPC_BuffReplace() {}
        public NPC_BuffReplace(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.RunningTime = reader.ReadFloat();
            this.Duration = reader.ReadFloat();
            this.NumInGroup = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteFloat(this.RunningTime);
            writer.WriteFloat(this.Duration);
            writer.WriteByte(this.NumInGroup);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}