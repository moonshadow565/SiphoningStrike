using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_SendSelectedObjID : GamePacket // 0x0B7
    {
        public override GamePacketID ID => GamePacketID.C2S_SendSelectedObjID;

        public uint ClientID { get; set; }
        public uint SelectedNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.ClientID = reader.ReadUInt32();
            this.SelectedNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.ClientID);
            writer.WriteUInt32(this.SelectedNetID);
        }
    }
}