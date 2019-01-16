using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_PopCharacterData : GamePacket // 0x06A
    {
        public override GamePacketID ID => GamePacketID.S2C_PopCharacterData;

        public uint PopID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            //TODO: ??
            if(reader.BytesLeft == 0)
            {
                this.PopID = 0xFFFFFFFF;
            }
            else 
            {
                this.PopID = reader.ReadUInt32();
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.PopID);
        }
    }
}