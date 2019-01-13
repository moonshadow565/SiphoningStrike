using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_StopAnimation : GamePacket // 0x02B
    {
        public override GamePacketID ID => GamePacketID.S2C_StopAnimation;

        public bool Fade { get; set; }
        public bool IgnoreLock { get; set; }
        public bool StopAll { get; set; }

        public S2C_StopAnimation() {}
        public S2C_StopAnimation(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            byte flags = reader.ReadByte();
            this.Fade = (flags & 1) != 0;
            this.IgnoreLock = (flags & 2) != 0;
            this.StopAll = (flags & 4) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            byte flags = 0;
            if (Fade)
                flags |= 1;
            if (IgnoreLock)
                flags |= 2;
            if (StopAll)
                flags |= 4;
            writer.WriteByte(flags);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}