using System;
namespace SiphoningStrike.Game.Common
{
    public abstract class LocalVisibilityData
    {
        internal abstract void ReadBodyInternal(ByteReader reader);
        internal abstract void WriteBodyInternal(ByteWriter writer);
    }

    static class LocalVisibilityDataExtension
    {
        public static LocalVisibilityData ReadLocalVisiblityData(this ByteReader reader)
        {
            LocalVisibilityData data;
            if(reader.BytesLeft > 0)
            {
                data = new LocalVisibilityDataAIBase();
            }
            else
            {
                data = new LocalVisibilityDataEmpty();
            }
            data.ReadBodyInternal(reader);
            return data;
        }

        public static void WriteLocalVisiblityData(this ByteWriter writer, LocalVisibilityData data)
        {
            if(data == null)
            {
                data = new LocalVisibilityDataAIBase();
            }
            data.WriteBodyInternal(writer);
        }
    }

    public class LocalVisibilityDataEmpty : LocalVisibilityData
    {
        internal override void ReadBodyInternal(ByteReader reader) {}
        internal override void WriteBodyInternal(ByteWriter writer){}
    }
     
    public class LocalVisibilityDataAIBase : LocalVisibilityData
    {
        public float MaxHealth { get; set; }
        public float Health { get; set; }

        internal override void ReadBodyInternal(ByteReader reader)
        {
            MaxHealth = reader.ReadFloat();
            Health = reader.ReadFloat();
        }
        internal override void WriteBodyInternal(ByteWriter writer)
        {
            writer.WriteFloat(MaxHealth);
            writer.WriteFloat(Health);
        }
    }

}
