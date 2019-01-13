using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetCircularMovementRestriction : GamePacket // 0x006
    {
        public override GamePacketID ID => GamePacketID.S2C_SetCircularMovementRestriction;
        public Vector3 Center { get; set; }
        public float Radius { get; set; }
        public bool RestrictCamera { get; set; }

        public S2C_SetCircularMovementRestriction() {}
        public S2C_SetCircularMovementRestriction(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Center = reader.ReadVector3();
            this.Radius = reader.ReadFloat();
            this.RestrictCamera = reader.ReadBool();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteVector3(this.Center);
            writer.WriteFloat(this.Radius);
            writer.WriteBool(this.RestrictCamera);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}