using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_MoveCameraToPoint : GamePacket // 0x027
    {
        public override GamePacketID ID => GamePacketID.S2C_MoveCameraToPoint;
        public bool StartFromCurrentPosition { get; set; }
        public Vector3 StartPosition { get; set; }
        public Vector3 TargetPosition { get; set; }
        public float TravelTime { get; set; }

        public S2C_MoveCameraToPoint() {}
        public S2C_MoveCameraToPoint(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.StartFromCurrentPosition = (bitfield & 0x01) != 0;

            this.StartPosition = reader.ReadVector3();
            this.TargetPosition = reader.ReadVector3();
            this.TravelTime = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            byte bitfield = 0;
            if (StartFromCurrentPosition)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteVector3(this.StartPosition);
            writer.WriteVector3(this.TargetPosition);
            writer.WriteFloat(this.TravelTime);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}