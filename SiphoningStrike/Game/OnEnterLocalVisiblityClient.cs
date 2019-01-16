using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class OnEnterLocalVisiblityClient : GamePacket // 0x0B5
    {
        public override GamePacketID ID => GamePacketID.OnEnterLocalVisiblityClient;

        public float MaxHealth { get; set; }
        public float Health { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            if (reader.BytesLeft > 0)
            {
                MaxHealth = reader.ReadFloat();
                Health = reader.ReadFloat();
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFloat(MaxHealth);
            writer.WriteFloat(Health);
        }
    }
}