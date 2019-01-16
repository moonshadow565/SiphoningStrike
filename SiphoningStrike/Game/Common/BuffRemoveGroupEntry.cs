using System;
namespace SiphoningStrike.Game.Common
{
    public class BuffRemoveGroupEntry
    {
        public uint UnitNetID { get; set; }
        public byte BuffSlot { get; set; }
    }

    static class BuffRemoveGroupEntryExtension
    {
        public static BuffRemoveGroupEntry ReadBuffRemoveGroupEntry(this ByteReader reader)
        {
            var data = new BuffRemoveGroupEntry();
            data.UnitNetID = reader.ReadUInt32();
            data.BuffSlot = reader.ReadByte();
            return data;
        }

        public static void WriteBuffRemoveGroupEntry(this ByteWriter writer, BuffRemoveGroupEntry data)
        {
            if (data == null)
            {
                data = new BuffRemoveGroupEntry();
            }
            writer.WriteUInt32(data.UnitNetID);
            writer.WriteByte(data.BuffSlot);
        }
    }
}
