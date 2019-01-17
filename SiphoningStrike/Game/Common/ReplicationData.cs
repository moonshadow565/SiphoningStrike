using System;
using System.Collections.Generic;
using System.IO;

namespace SiphoningStrike.Game.Common
{
    public class ReplicationData
    {
        public uint UnitNetID { get; set; }
        public Dictionary<int, Dictionary<int, uint>> Values { get; set; }
            = new Dictionary<int, Dictionary<int, uint>>();
    }

    static class ReplicationDataExtension
    {
        public static ReplicationData ReadReplicationData(this ByteReader reader)
        {
            var data = new ReplicationData();
            uint primaryIdArray = reader.ReadByte();
            data.UnitNetID = reader.ReadUInt32();
            for (var primaryId = 0; primaryId < 8; primaryId++)
            {
                if((primaryIdArray & (1 << primaryId)) == 0)
                {
                    continue;
                }
                uint secondaryIdArray = reader.ReadUInt32();
                var array = new Dictionary<int, uint>();
                data.Values.Add(primaryId, array);
                for (var secondaryId = 0; secondaryId < 32; secondaryId++)
                {
                    if ((secondaryIdArray & (1 << secondaryId)) == 0)
                    {
                        continue;
                    }
                    var value = reader.ReadUInt32();
                    array.Add(secondaryId, value);
                }
            }
            return data;
        }

        public static void WriteReplicationData(this ByteWriter writer, ReplicationData data)
        {
            if(data == null)
            {
                data = new ReplicationData();
            }

            byte primaryIdArray = 0;
            foreach(var kvp in data.Values)
            {
                if(kvp.Key > 7 || kvp.Key < 0)
                {
                    throw new IOException("PrimaryID too big!");
                }
                primaryIdArray |= (byte)(1u << kvp.Key);
            }
            writer.WriteByte(primaryIdArray);
            writer.WriteUInt32(data.UnitNetID);

            for (var primaryId = 0; primaryId < 8; primaryId++)
            {
                if ((primaryIdArray & (1 << primaryId)) == 0)
                {
                    continue;
                }
                var array = data.Values[primaryId];
                uint secondaryIdArray = 0;
                foreach(var kvp in array)
                {
                    if(kvp.Key > 31 || kvp.Key < 0)
                    {
                        throw new IOException("Secondary ID too big!");
                    }
                    secondaryIdArray |= (1u << kvp.Key);
                }
                writer.WriteUInt32(secondaryIdArray);
                for (var secondaryId = 0; secondaryId < 32; secondaryId++)
                {
                    if ((secondaryIdArray & (1 << secondaryId)) == 0)
                    {
                        continue;
                    }
                    writer.WriteUInt32(array[secondaryId]);
                }
            }
        }
    }
}
