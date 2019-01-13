using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SetFadeOut_Pop : GamePacket // 0x034
    {
        public override GamePacketID ID => GamePacketID.SetFadeOut_Pop;

        public short StackID { get; set; }

        public SetFadeOut_Pop() {}
        public SetFadeOut_Pop(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.StackID = reader.ReadInt16();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteInt16(this.StackID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}