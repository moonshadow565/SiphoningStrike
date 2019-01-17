using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetAnimStates : GamePacket // 0x06E
    {
        public override GamePacketID ID => GamePacketID.S2C_SetAnimStates;

        public Dictionary<string, string> AnimationOverrides { get; set; } = new Dictionary<string, string>();

        internal override void ReadBody(ByteReader reader)
        {
            int number = reader.ReadByte();
            for (int i = 0; i < number; i++)
            {
                var fromAnim = reader.ReadSizedString();
                var toAnim = reader.ReadSizedString();
                this.AnimationOverrides[fromAnim] = toAnim;
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            int number = this.AnimationOverrides.Count;
            if (number > 0xFF)
            {
                throw new IOException("AnimationOverrides list too big!");
            }
            foreach (var kvp in this.AnimationOverrides)
            {
                writer.WriteSizedString(kvp.Key);
                writer.WriteSizedString(kvp.Value);
            }
        }
    }
}