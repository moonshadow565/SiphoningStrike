using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SiphoningStrike
{
    using LoadScreenDict = Dictionary<LoadScreenPacketID, Func<LoadScreenPacket>>;
    public abstract class LoadScreenPacket : BasePacket
    {
        public abstract LoadScreenPacketID ID { get; }

        internal abstract void ReadBody(ByteReader reader);

        internal override void ReadPacket(ByteReader reader)
        {
            reader.ReadByte();
            ReadBody(reader);
        }

        internal abstract void WriteBody(ByteWriter writer);

        internal override void WritePacket(ByteWriter writer)
        {
            writer.WriteByte((byte)this.ID);
            WriteBody(writer);
        }

        internal static LoadScreenDict GenerateLookup()
        {
            var lookup = new LoadScreenDict();
            foreach (Type type in Assembly.GetAssembly(typeof(LoadScreenPacket)).GetTypes())
            {
                if (!type.IsClass || type.IsAbstract && !type.IsSubclassOf(typeof(LoadScreenPacket)))
                {
                    continue;
                }
                var tmp = (LoadScreenPacket)Activator.CreateInstance(type);
                var id = tmp.ID;
                if (lookup.ContainsKey(id))
                {
                    throw new Exception("ID already in lookup map");
                }
                var lambda = Expression.Lambda<Func<LoadScreenPacket>>(
                    Expression.New(type),
                    Array.Empty<ParameterExpression>()
                ).Compile();
                lookup.Add(id, lambda);
            }
            return lookup;
        }
        internal static readonly LoadScreenDict Lookup = GenerateLookup();
    }
}
