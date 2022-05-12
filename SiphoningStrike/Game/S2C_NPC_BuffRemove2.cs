using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_NPC_BuffRemove2 : GamePacket // 0x07F
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_BuffRemove2;

        public byte BuffSlot { get; set; }
        public uint BuffNameHash { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.BuffSlot = reader.ReadByte();
            this.BuffNameHash = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.BuffSlot);
            writer.WriteUInt32(this.BuffNameHash);
        }
    }
}