using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FadeOutMainSFX : GamePacket // 0x062
    {
        public override GamePacketID ID => GamePacketID.S2C_FadeOutMainSFX;

        public float FadeTime { get; set; }

        public S2C_FadeOutMainSFX() {}
        public S2C_FadeOutMainSFX(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.FadeTime = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteFloat(this.FadeTime);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}