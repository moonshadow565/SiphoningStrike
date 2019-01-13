using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class DisplayFloatingText : GamePacket // 0x01C
    {
        public override GamePacketID ID => GamePacketID.DisplayFloatingText;

        public uint TargetNetID { get; set; }
        public byte FloatingTextType { get; set; }
        public int Param { get; set; }
        public string Message { get; set; } = "";

        public DisplayFloatingText() {}
        public DisplayFloatingText(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.TargetNetID = reader.ReadUInt32();
            this.FloatingTextType = reader.ReadByte();
            this.Param = reader.ReadInt32();
            this.Message = reader.ReadFixedStringLast(128);

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.TargetNetID);
            writer.WriteByte(this.FloatingTextType);
            writer.WriteInt32(this.Param);
            writer.WriteFixedStringLast(this.Message, 128);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}