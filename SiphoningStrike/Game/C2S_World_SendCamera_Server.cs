using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_World_SendCamera_Server : GamePacket // 0x030
    {
        public override GamePacketID ID => GamePacketID.C2S_World_SendCamera_Server;

        public Vector3 CameraPosition { get; set; }
        public Vector3 CameraDirection { get; set; }
        public uint ClientID { get; set; }
        public SByte SyncID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.CameraPosition = reader.ReadVector3();
            this.CameraDirection = reader.ReadVector3();
            this.ClientID = reader.ReadUInt32();
            this.SyncID = reader.ReadSByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(this.CameraPosition);
            writer.WriteVector3(this.CameraDirection);
            writer.WriteUInt32(this.ClientID);
            writer.WriteSByte(this.SyncID);
        }
    }
}