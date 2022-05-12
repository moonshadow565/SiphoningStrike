using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace SiphoningStrike.Game.Common
{
    public class CastTargetInfo
    {
        public uint UnitNetID { get; set; }
        public Vector3 Position { get; set; }
        public byte HitResult { get; set; }
    }

    static class CastTargetInfoExtension
    {
        public static CastTargetInfo ReadCastTargetInfo(this ByteReader reader)
        {
            var data = new CastTargetInfo();
            data.UnitNetID = reader.ReadUInt32();
            data.Position = reader.ReadVector3();
            data.HitResult = reader.ReadByte();
            return data;
        }
        public static void WriteCastTargetInfo(this ByteWriter writer, CastTargetInfo data)
        {
            if (data == null)
            {
                data = new CastTargetInfo();   
            }
            writer.WriteUInt32(data.UnitNetID);
            writer.WriteVector3(data.Position);
            writer.WriteByte(data.HitResult);
        }
    }


    public class CastInfo
    {
        public uint SpellHash { get; set; } 
        public uint SpellNetID { get; set; } 
        public byte SpellLevel { get; set; } 
        public float AttackSpeedModifier { get; set; } 
        public uint CasterNetID { get; set; } 
        public uint MissileNetID { get; set; } 
        public Vector3 TargetPosition { get; set; }
        public Vector3 TargetPositionEnd { get; set; }

        public List<CastTargetInfo> TargetsInfo { get; set; } = new List<CastTargetInfo>();

        public float DesignerCastTime { get; set; }
        public float ExtraCastTime { get; set; } 
        public float DesignerTotalTime { get; set; } 
        public float Cooldown { get; set; }
        public float StartCastTime { get; set; }

        //bitfield byte
        public bool IsAutoAttack { get; set; }
        public bool IsSecondAutoAttack { get; set; }
        public bool IsForceCastingOrChannel { get; set; }
        public bool IsOverrideCastPosition { get; set; }

        public byte SpellSlot { get; set; }
        public float ManaCost { get; set; }
        public Vector3 CastLaunchPosition { get; set; }


    }
    static class CastInfoExtension
    {
        public static CastInfo ReadCastInfo(this ByteReader readerOrg)
        {
            var data = new CastInfo();
            var size = readerOrg.ReadUInt16();
            var buffer = readerOrg.ReadBytes(size - 2);
            var reader = new ByteReader(buffer);

            data.SpellHash = reader.ReadUInt32();
            data.SpellNetID = reader.ReadUInt32();
            data.SpellLevel = reader.ReadByte();
            data.AttackSpeedModifier = reader.ReadFloat();
            data.CasterNetID = reader.ReadUInt32();
            data.MissileNetID = reader.ReadUInt32();
            data.TargetPosition = reader.ReadVector3();
            data.TargetPositionEnd = reader.ReadVector3();

            var targetsCount = reader.ReadByte();
            if(targetsCount >= 32)
            {
                throw new IOException("Too many targets!");
            }
            for (var i = 0; i < targetsCount; i++)
            {
                data.TargetsInfo.Add(reader.ReadCastTargetInfo());
            }

            data.DesignerCastTime = reader.ReadFloat();
            data.ExtraCastTime = reader.ReadFloat();
            data.DesignerTotalTime = reader.ReadFloat();
            data.Cooldown = reader.ReadFloat();
            data.StartCastTime = reader.ReadFloat();

            byte bitfield = reader.ReadByte();
            data.IsAutoAttack = (bitfield & 1) != 0;
            data.IsSecondAutoAttack = (bitfield & 2) != 0;
            data.IsForceCastingOrChannel = (bitfield & 4) != 0;
            data.IsOverrideCastPosition = (bitfield & 8) != 0;

            data.SpellSlot = reader.ReadByte();
            data.ManaCost = reader.ReadFloat();
            data.CastLaunchPosition = reader.ReadVector3();
            return data;
        }

        public static void WriteCastInfo(this ByteWriter writerOrg, CastInfo data)
        {
            var writer = new ByteWriter();

            writer.WriteUInt32(data.SpellHash);
            writer.WriteUInt32(data.SpellNetID);
            writer.WriteByte(data.SpellLevel);
            writer.WriteFloat(data.AttackSpeedModifier);
            writer.WriteUInt32(data.CasterNetID);
            writer.WriteUInt32(data.MissileNetID);
            writer.WriteVector3(data.TargetPosition);
            writer.WriteVector3(data.TargetPositionEnd);

            int targetsCount = data.TargetsInfo.Count;
            if (targetsCount >= 32)
            {
                throw new IOException("Too many targets!");
            }
            writer.WriteByte((byte)targetsCount);
            for (var i = 0; i < targetsCount; i++)
            {
                writer.WriteCastTargetInfo(data.TargetsInfo[i]);
            }

            writer.WriteFloat(data.DesignerCastTime);
            writer.WriteFloat(data.ExtraCastTime);
            writer.WriteFloat(data.DesignerTotalTime);
            writer.WriteFloat(data.Cooldown);
            writer.WriteFloat(data.StartCastTime);

            byte bitfield = 0;
            if (data.IsAutoAttack)
            {
                bitfield |= 0x01;
            }
            if (data.IsSecondAutoAttack)
            {
                bitfield |= 0x02;
            }
            if (data.IsForceCastingOrChannel)
            {
                bitfield |= 0x04;
            }
            if (data.IsOverrideCastPosition)
            {
                bitfield |= 0x08;
            }
            writer.WriteByte(bitfield);

            writer.WriteByte(data.SpellSlot);
            writer.WriteFloat(data.ManaCost);
            writer.WriteVector3(data.CastLaunchPosition);


            var writerData = writer.GetBytes();
            int size = writerData.Length + 2;
            writer.WriteUInt16((ushort)size);
            writer.WriteBytes(writerData);
        }
    }
}
