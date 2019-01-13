using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_FaceDirection : GamePacket // 0x053
    {
        public override GamePacketID ID => GamePacketID.S2C_FaceDirection;

        public Vector3 Direction { get; set; }

        public S2C_FaceDirection() {}
        public S2C_FaceDirection(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Direction = reader.ReadVector3();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteVector3(Direction);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}