﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace SiphoningStrike.Game.Common
{
    public enum MovementDataType : byte
    {
        None = 0,
        WithSpeed = 1,
        Normal = 2,
        Stop = 3,
    }

    public abstract class MovementData
    {
        public abstract MovementDataType Type { get; }
        public int SyncID { get; set; }
        internal abstract void Write(ByteWriter writer);
    }

    static class MovementDataExtension
    {
        public static MovementData ReadMovementDataWithHeader(this ByteReader reader)
        {
            var type = (MovementDataType)reader.ReadByte();
            var syncID = reader.ReadInt32();
            switch (type)
            {
                case MovementDataType.Stop:
                    return new MovementDataStop(reader, syncID);
                case MovementDataType.Normal:
                    return new MovementDataNormal(reader, syncID);
                case MovementDataType.WithSpeed:
                    return new MovementDataWithSpeed(reader, syncID);
                default:
                    return new MovementDataNone(reader, syncID);
            }
        }

        public static void WriteMovementDataWithHeader(this ByteWriter writer, MovementData data)
        {
            if(data == null)
            {
                data = new MovementDataNone();
            }
            writer.WriteByte((byte)data.Type);
            writer.WriteInt32(data.SyncID);
            data.Write(writer);
        }
    }


    public class MovementDataNone : MovementData
    {
        public override MovementDataType Type => MovementDataType.None;

        internal override void Write(ByteWriter writer)
        {
        }
        public MovementDataNone() { }
        internal MovementDataNone(ByteReader reader, int syncID)
        {
        }
    }

    public class MovementDataStop : MovementData
    {
        public override MovementDataType Type => MovementDataType.Stop;
        public Vector2 Position { get; set; }
        public Vector2 Forward { get; set; }

        public MovementDataStop() { }
        internal MovementDataStop(ByteReader reader, int syncID)
        {
            this.SyncID = syncID;
            Position = reader.ReadVector2();
            Forward = reader.ReadVector2();
        }

        internal override void Write(ByteWriter writer)
        {
            writer.WriteVector2(Position);
            writer.WriteVector2(Forward);
        }
    }

    public class MovementDataNormal : MovementData
    {
        public override MovementDataType Type => MovementDataType.Normal;
        public uint TeleportNetID { get; set; }
        public bool HasTeleportID { get; set; }
        public byte TeleportID { get; set; }
        public List<CompressedWaypoint> Waypoints { get; set; }

        public MovementDataNormal() { }

        internal MovementDataNormal(ByteReader reader, int syncID)
        {
            this.SyncID = syncID;
            ushort bitfield = reader.ReadUInt16();
            HasTeleportID = (bitfield & 1) != 0;

            ushort bitfield2 = reader.ReadUInt16();
            byte size = (byte)(bitfield2 & 0x7F);
            if (size > 0)
            {
                TeleportNetID = reader.ReadUInt32();
                if (HasTeleportID)
                {
                    TeleportID = reader.ReadByte();
                }
                Waypoints = reader.ReadCompressedWaypoints(size);
            }
        }

        internal override void Write(ByteWriter writer)
        {
            int waypointsSize = Waypoints.Count;
            if (waypointsSize > 0x7F)
            {
                throw new Exception("Too many paths > 0x7F!");
            }

            ushort bitfield = 0;
            if (HasTeleportID)
            {
                bitfield |= 1;
            }
            writer.WriteUInt16(bitfield);

            ushort bitfield2 = 0;
            if (Waypoints != null)
            {
                bitfield2 |= (byte)(waypointsSize & 0x7F);
            }
            writer.WriteUInt16(bitfield2);

            if (Waypoints != null)
            {
                writer.WriteUInt32(TeleportNetID);
                if (HasTeleportID)
                {
                    writer.WriteByte(TeleportID);
                }
                writer.WriteCompressedWaypoints(Waypoints);
            }
        }
    }

    public class MovementDataWithSpeed : MovementDataNormal
    {
        public override MovementDataType Type => MovementDataType.WithSpeed;
        public SpeedParams SpeedParams { get; set; } = new SpeedParams();

        public MovementDataWithSpeed() { }

        internal MovementDataWithSpeed(ByteReader reader, int syncID)
        {
            this.SyncID = syncID;
            ushort bitfield = reader.ReadUInt16();
            HasTeleportID = (bitfield & 1) != 0;

            ushort bitfield2 = reader.ReadUInt16();
            byte size = (byte)(bitfield2 & 0x7F);
            if (size > 0)
            {
                TeleportNetID = reader.ReadUInt32();
                if (HasTeleportID)
                {
                    TeleportID = reader.ReadByte();
                }
                SpeedParams = reader.ReadWaypointSpeedParams();
                Waypoints = reader.ReadCompressedWaypoints(size);
            }
        }

        internal override void Write(ByteWriter writer)
        {
            int waypointsSize = Waypoints.Count;
            if (waypointsSize > 0x7F)
            {
                throw new Exception("Too many paths > 0x7F!");
            }

            ushort bitfield = 0;
            if (HasTeleportID)
            {
                bitfield |= 1;
            }
            writer.WriteUInt16(bitfield);

            ushort bitfield2 = 0;
            if (Waypoints != null)
            {
                bitfield2 |= (byte)(waypointsSize & 0x7F);
            }
            writer.WriteUInt16(bitfield2);

            if (Waypoints != null)
            {
                writer.WriteUInt32(TeleportNetID);
                if (HasTeleportID)
                {
                    writer.WriteByte(TeleportID);
                }
                writer.WriteSpeedParams(SpeedParams);
                writer.WriteCompressedWaypoints(Waypoints);
            }
        }
    }
}
