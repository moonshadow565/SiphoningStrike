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

        public S2C_SetAnimStates() {}
        public S2C_SetAnimStates(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            int number = reader.ReadByte();
            for (int i = 0; i < number; i++)
            {
                var fromAnim = reader.ReadSizedString();
                var toAnim = reader.ReadSizedString();
                this.AnimationOverrides[fromAnim] = toAnim;
            }

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

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

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}