using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SiphoningStrike
{

    using GamePacketDict = Dictionary<GamePacketID, Func<GamePacket>>;
    public abstract class GamePacket : BasePacket
    {
        public abstract GamePacketID ID { get; }
        public uint SenderNetID { get; set; }

        internal abstract void ReadBody(ByteReader reader);

        internal override void ReadPacket(ByteReader reader)
        {
            var id = (GamePacketID)reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();
            if(id == GamePacketID.ExtendedPacket)
            {
                reader.ReadUInt16();
            }

            ReadBody(reader);
        }

        internal abstract void WriteBody(ByteWriter writer);

        internal override void WritePacket(ByteWriter writer)
        {
            var id = (ushort)(this.ID);
            if (id > 0xFF)
            {
                writer.WriteByte(0xFE);
            }
            else
            {
                writer.WriteByte((byte)id);
            }
            writer.WriteUInt32(this.SenderNetID);
            if(id > 0xFF)
            {
                writer.WriteUInt16(id);
            }

            WriteBody(writer);
        }

        internal static GamePacketDict GenerateLookup()
        {
            var lookup = new GamePacketDict();
            foreach (Type type in Assembly.GetAssembly(typeof(GamePacket)).GetTypes())
            {
                if (!type.IsClass || type.IsAbstract && !type.IsSubclassOf(typeof(GamePacket)))
                {
                    continue;
                }
                var tmp = (GamePacket)Activator.CreateInstance(type);
                var id = tmp.ID;
                if(lookup.ContainsKey(id))
                {
                    throw new Exception("ID already in lookup map");
                }
                var lambda = Expression.Lambda<Func<GamePacket>>(
                    Expression.New(type), 
                    Array.Empty<ParameterExpression>()
                ).Compile();
                lookup.Add(id, lambda);
            }
            return lookup;
        }
        internal static readonly GamePacketDict Lookup = GenerateLookup();
    }
}
