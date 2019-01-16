using System;
namespace SiphoningStrike.Game.Common
{
    public class BuffAddGroupEntry
    {
        public uint UnitNetID { get; set; }
        public uint CasterNetID { get; set; }
        public byte BuffSlot { get; set; }
        public byte Count { get; set; }
        public bool IsHidden { get; set; }
    }

    static class BuffAddGroupEntryExtension
    {
        public static BuffAddGroupEntry ReadBuffAddGroupEntry(this ByteReader reader)
        {
            var data = new BuffAddGroupEntry();
            data.UnitNetID = reader.ReadUInt32();
            data.CasterNetID = reader.ReadUInt32();
            data.BuffSlot = reader.ReadByte();
            data.Count = reader.ReadByte();
            data.IsHidden = reader.ReadBool();
            return data;
        }

        public static void WriteBuffAddGoupEntry(this ByteWriter writer, BuffAddGroupEntry data)
        {
            if(data == null)
            {
                data = new BuffAddGroupEntry();
            }
            writer.WriteUInt32(data.UnitNetID);
            writer.WriteUInt32(data.CasterNetID);
            writer.WriteByte(data.BuffSlot);
            writer.WriteByte(data.Count);
            writer.WriteBool(data.IsHidden);
        }
    }
}
