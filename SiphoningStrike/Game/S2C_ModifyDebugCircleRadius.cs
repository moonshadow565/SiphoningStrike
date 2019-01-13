using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ModifyDebugCircleRadius : GamePacket // 0x02F
    {
        public override GamePacketID ID => GamePacketID.S2C_ModifyDebugCircleRadius;

        public uint CircleID { get; set; }
        public float Radius { get; set; }

        public S2C_ModifyDebugCircleRadius() {}
        public S2C_ModifyDebugCircleRadius(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.CircleID = reader.ReadUInt32();
            this.Radius = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.CircleID);
            writer.WriteFloat(this.Radius);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}