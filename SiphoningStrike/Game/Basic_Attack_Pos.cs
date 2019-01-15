using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Basic_Attack_Pos : GamePacket // 0x01D
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack_Pos;

        public BasicAttackData BasicAttackData { get; set; } = new BasicAttackData();
        public Vector2 Position { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.BasicAttackData = reader.ReadBasicAttackData();
            this.Position = reader.ReadVector2();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBasicAttackData(this.BasicAttackData);
            writer.WriteVector2(this.Position);
        }
    }
}