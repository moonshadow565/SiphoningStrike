using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_GlobalCombatMessage : GamePacket // 0x085
    {
        public override GamePacketID ID => GamePacketID.S2C_GlobalCombatMessage;

        public uint MessageType { get; set; }
        public uint ObjectNameNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.MessageType = reader.ReadUInt32();
            this.ObjectNameNetID = reader.ReadUInt32();
        }

        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.MessageType);
            writer.WriteUInt32(this.ObjectNameNetID);
        }
    }
}