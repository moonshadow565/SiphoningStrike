using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_NPC_LevelUp : GamePacket // 0x045
    {
        public override GamePacketID ID => GamePacketID.S2C_NPC_LevelUp;

        public byte Level { get; set; }
        public byte AveliablePoints { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Level = reader.ReadByte();
            this.AveliablePoints = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.Level);
            writer.WriteByte(this.AveliablePoints);
        }
    }
}