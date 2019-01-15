using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_Hero_Die : GamePacket // 0x061
    {
        public override GamePacketID ID => GamePacketID.NPC_Hero_Die;

        public DeathData DeathData { get; set; } = new DeathData();

        internal override void ReadBody(ByteReader reader)
        {
            this.DeathData = reader.ReadDeathData();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteDeathData(this.DeathData);

        }
    }
}