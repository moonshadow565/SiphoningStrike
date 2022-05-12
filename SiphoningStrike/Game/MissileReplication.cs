using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class MissileReplication : GamePacket // 0x041
    {
        public override GamePacketID ID => GamePacketID.S2C_MissileReplication;

        public Vector3 Position { get; set; }
        public Vector3 CasterPosition { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 StartPoint { get; set; }
        public Vector3 EndPoint { get; set; }
        public Vector3 UnitPosition { get; set; }
        public float Speed { get; set; }
        public float LifePercentage { get; set; }
        public byte Bounced { get; set; }
        public CastInfo CastInfo { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Position = reader.ReadVector3();
            this.CasterPosition = reader.ReadVector3();
            this.Direction = reader.ReadVector3();
            this.Velocity = reader.ReadVector3();
            this.StartPoint = reader.ReadVector3();
            this.EndPoint = reader.ReadVector3();
            this.UnitPosition = reader.ReadVector3();
            this.Speed = reader.ReadFloat();
            this.LifePercentage = reader.ReadFloat();
            this.Bounced = reader.ReadByte();
            this.CastInfo = reader.ReadCastInfo();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(this.Position);
            writer.WriteVector3(this.CasterPosition);
            writer.WriteVector3(this.Direction);
            writer.WriteVector3(this.Velocity);
            writer.WriteVector3(this.StartPoint);
            writer.WriteVector3(this.EndPoint);
            writer.WriteVector3(this.UnitPosition);
            writer.WriteFloat(this.Speed);
            writer.WriteFloat(this.LifePercentage);
            writer.WriteByte(this.Bounced);
            writer.WriteCastInfo(this.CastInfo);
        }
    }
}