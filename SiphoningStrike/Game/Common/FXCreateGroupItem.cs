using System;
using System.Numerics;

namespace SiphoningStrike.Game.Common
{
    public class FXCreateGroupItem
    {
        public uint TargetNetID { get; set; }
        public uint NetAssignedNetID { get; set; }
        public uint BindNetID { get; set; }
        public short PositionX { get; set; }
        public float PositionY { get; set; }
        public short PositionZ { get; set; }
        public short TargetPositionX { get; set; }
        public float TargetPositionY { get; set; }
        public short TargetPositionZ { get; set; }
        public short OwnerPositionX { get; set; }
        public float OwnerPositionY { get; set; }
        public short OwnerPositionZ { get; set; }
        public Vector3 OrientationVector { get; set; }
        public float TimeSpent { get; set; }
    }

    static class FXCreateGroupItemExtension
    {
        public static FXCreateGroupItem ReadFXCreateGroupItem(this ByteReader reader)
        {
            var data = new FXCreateGroupItem();
            data.TargetNetID = reader.ReadUInt32();
            data.NetAssignedNetID = reader.ReadUInt32();
            data.BindNetID = reader.ReadUInt32();
            data.PositionX = reader.ReadInt16();
            data.PositionY = reader.ReadFloat();
            data.PositionZ = reader.ReadInt16();
            data.TargetPositionX = reader.ReadInt16();
            data.TargetPositionY = reader.ReadFloat();
            data.TargetPositionZ = reader.ReadInt16();
            data.OwnerPositionX = reader.ReadInt16();
            data.OwnerPositionY = reader.ReadFloat();
            data.OwnerPositionZ = reader.ReadInt16();
            data.OrientationVector = reader.ReadVector3();
            data.TimeSpent = reader.ReadFloat();
            return data;
        }
        public static void WriteFXCreateGroupItem(this ByteWriter writer, FXCreateGroupItem data)
        {
            if(data == null)
            {
                data = new FXCreateGroupItem();
            }
            writer.WriteUInt32(data.TargetNetID);
            writer.WriteUInt32(data.NetAssignedNetID);
            writer.WriteUInt32(data.BindNetID);
            writer.WriteInt16(data.PositionX);
            writer.WriteFloat(data.PositionY);
            writer.WriteInt16(data.PositionZ);
            writer.WriteInt16(data.TargetPositionX);
            writer.WriteFloat(data.TargetPositionY);
            writer.WriteInt16(data.TargetPositionZ);
            writer.WriteInt16(data.OwnerPositionX);
            writer.WriteFloat(data.OwnerPositionY);
            writer.WriteInt16(data.OwnerPositionZ);
            writer.WriteVector3(data.OrientationVector);
            writer.WriteFloat(data.TimeSpent);
        }
    }
}
