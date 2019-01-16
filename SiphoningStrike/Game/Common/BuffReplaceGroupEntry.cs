using System;
namespace SiphoningStrike.Game.Common
{
    public class BuffReplaceGroupEntry
    {
        public uint UnitNetID { get; set; }
        public uint CasterNetID { get; set; }
        public byte BuffSlot { get; set; }
    }

    static class BuffReplaceGroupEntryExtension
    {
        public static BuffReplaceGroupEntry ReadBuffReplaceGroupEntry(this ByteReader reader)
        {
            var data = new BuffReplaceGroupEntry();
            data.UnitNetID = reader.ReadUInt32();
            data.CasterNetID = reader.ReadUInt32();
            data.BuffSlot = reader.ReadByte();
            return data;
        }

        public static void WriteBuffReplaceGroupEntry(this ByteWriter writer, BuffReplaceGroupEntry data)
        {
            if (data == null)
            {
                data = new BuffReplaceGroupEntry();
            }
            writer.WriteUInt32(data.UnitNetID);
            writer.WriteUInt32(data.CasterNetID);
            writer.WriteByte(data.BuffSlot);
        }
    }
}
