using System;
using System.Collections.Generic;
using System.IO;

namespace SiphoningStrike.Game.Common
{
    public class FXCreateGroupEntry
    {
        public uint EffectNameHash { get; set; }
        public ushort Flags { get; set; }
        public uint TargetBoneNameHash { get; set; }
        public uint BoneNameHash { get; set; }
        public List<FXCreateGroupItem> FXCreateData { get; set; } = new List<FXCreateGroupItem>();
    }

    static class FXCreateGroupEntryExtension
    {
        public static FXCreateGroupEntry ReadFXCreateGroupEntry(this ByteReader reader)
        {
            var data = new FXCreateGroupEntry();
            data.EffectNameHash = reader.ReadUInt32();
            data.Flags = reader.ReadUInt16();
            data.TargetBoneNameHash = reader.ReadUInt32();
            data.BoneNameHash = reader.ReadUInt32();
            int count = reader.ReadByte();
            for (int i = 0; i < count; i++)
            {
                data.FXCreateData.Add(reader.ReadFXCreateGroupItem());
            }
            return data;
        }

        public static void WriteFXCreateGroupEntry(this ByteWriter writer, FXCreateGroupEntry data)
        {
            if(data == null)
            {
                data = new FXCreateGroupEntry();
            }
            writer.WriteUInt32(data.EffectNameHash);
            writer.WriteUInt16(data.Flags);
            writer.WriteUInt32(data.TargetBoneNameHash);
            writer.WriteUInt32(data.BoneNameHash);
            int count = data.FXCreateData.Count;
            if (count > 0xFF)
            {
                throw new IOException("FXCreateData list too big > 255!");
            }
            writer.WriteByte((byte)count);
            foreach (var fx in data.FXCreateData)
            {
                writer.WriteFXCreateGroupItem(fx);
            }
        }
    }
}
