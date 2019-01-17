using System;
namespace SiphoningStrike.Game.Common
{
    public class BuffUpdateCountGroupEntry
    {
        public uint UnitNetID { get; set; }
        public uint CasterNetID { get; set; }
        public byte BuffSlot { get; set; }
        public byte Count { get; set; }
    }

    static class BuffUpdateCountGroupEntryExtension
    {
        public static BuffUpdateCountGroupEntry ReadBuffUpdateCountGroupEntry(this ByteReader reader)
        {
            var data = new BuffUpdateCountGroupEntry();
            data.UnitNetID = reader.ReadUInt32();
            data.CasterNetID = reader.ReadUInt32();
            data.BuffSlot = reader.ReadByte();
            data.Count = reader.ReadByte();
            return data;
        }

        public static void WriteBuffUpdateCountGroupEntry(this ByteWriter writer, BuffUpdateCountGroupEntry data)
        {
            if (data == null)
            {
                data = new BuffUpdateCountGroupEntry();
            }
            writer.WriteUInt32(data.UnitNetID);
            writer.WriteUInt32(data.CasterNetID);
            writer.WriteByte(data.BuffSlot);
            writer.WriteByte(data.Count);
        }
    }
}
