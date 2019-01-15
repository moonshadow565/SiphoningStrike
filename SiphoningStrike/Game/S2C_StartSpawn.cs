using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_StartSpawn : GamePacket // 0x065
    {
        public override GamePacketID ID => GamePacketID.S2C_StartSpawn;

        public byte BotCountOrder { get; set; }
        public byte BotCountChaos { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.BotCountOrder = reader.ReadByte();
            this.BotCountChaos = reader.ReadByte();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(BotCountOrder);
            writer.WriteByte(BotCountChaos);

        }
    }
}