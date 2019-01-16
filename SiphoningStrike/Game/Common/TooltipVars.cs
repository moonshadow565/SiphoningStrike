using System;
namespace SiphoningStrike.Game.Common
{
    public class TooltipVars
    {
        private float[] _values = new float[3];

        public uint OwnerNetID { get; set; }
        public byte SlotIndex { get; set; }
        public float[] Values => _values;
    }

    static class TooltipVarsExtension
    {
        public static TooltipVars ReadTooltipVars(this ByteReader reader)
        {
            var data = new TooltipVars();
            data.OwnerNetID = reader.ReadUInt32();
            data.SlotIndex = reader.ReadByte();
            for (int i = 0; i < data.Values.Length; i++)
            {
                data.Values[i] = reader.ReadFloat();
            }
            return data;
        }

        public static void WriteTooltipVars(this ByteWriter writer, TooltipVars data)
        {
            if (data == null)
            {
                data = new TooltipVars();
            }
            writer.WriteUInt32(data.OwnerNetID);
            writer.WriteByte(data.SlotIndex);
            for (int i = 0; i < data.Values.Length; i++)
            {
                writer.WriteFloat(data.Values[i]);
            }
        }
    }
}
