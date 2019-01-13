using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ServerTick : GamePacket // 0x02A
    {
        public override GamePacketID ID => GamePacketID.ServerTick;

        public float Delta { get; set; }

        public ServerTick() {}
        public ServerTick(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Delta = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteFloat(this.Delta);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}