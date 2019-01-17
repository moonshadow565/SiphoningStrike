using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetFoWStatus : GamePacket // 0x0B4
    {
        public override GamePacketID ID => GamePacketID.S2C_SetFoWStatus;

        public bool Enabled { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            //FIXME: riot?
            if(reader.BytesLeft > 0)
            {
                this.Enabled = reader.ReadBool();
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.Enabled);
        }
    }
}