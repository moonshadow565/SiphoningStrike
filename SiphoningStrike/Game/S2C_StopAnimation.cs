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

        internal override void ReadBody(ByteReader reader)
        {
            byte flags = reader.ReadByte();
            this.Fade = (flags & 1) != 0;
            this.IgnoreLock = (flags & 2) != 0;
            this.StopAll = (flags & 4) != 0;
            //FIXME: riot?
            if(reader.BytesLeft == 3)
            {
                reader.ReadPad(3);
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte flags = 0;
            if (Fade)
                flags |= 1;
            if (IgnoreLock)
                flags |= 2;
            if (StopAll)
                flags |= 4;
            writer.WriteByte(flags);
        }
    }
}