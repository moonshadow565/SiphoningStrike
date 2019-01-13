using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SetFrequency : GamePacket // 0x013
    {
        public override GamePacketID ID => GamePacketID.SetFrequency;
        public float NewFrequency { get; set; }

        public SetFrequency() {}
        public SetFrequency(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.NewFrequency = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteFloat(this.NewFrequency);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}