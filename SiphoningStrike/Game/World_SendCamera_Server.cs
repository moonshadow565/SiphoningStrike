using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class World_SendCamera_Server : GamePacket // 0x030
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server;

        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraDirection { get; set; }
        public uint ClientID { get; set; }
        public SByte SyncID { get; set; }

        public World_SendCamera_Server() {}
        public World_SendCamera_Server(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.CameraPosition = reader.ReadVector3();
            this.CameraDirection = reader.ReadVector3();
            this.ClientID = reader.ReadUInt32();
            this.SyncID = reader.ReadSByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteVector3(this.CameraPosition);
            writer.WriteVector3(this.CameraDirection);
            writer.WriteUInt32(this.ClientID);
            writer.WriteSByte(this.SyncID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}