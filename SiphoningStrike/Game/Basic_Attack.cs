using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Basic_Attack : GamePacket // 0x00D
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack;

        public BasicAttackData BasicAttackData { get; set; } = new BasicAttackData();
        internal override void ReadBody(ByteReader reader)
        {
            this.BasicAttackData = reader.ReadBasicAttackData();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBasicAttackData(this.BasicAttackData);
        }
    }
}