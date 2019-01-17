using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace SiphoningStrike.Game.Events
{
    using EventDict = Dictionary<EventID, Func<BaseEvent>>;
    public abstract class BaseEvent
    {
        public abstract EventID ID { get; }
        public abstract ArgsBase ArgsBase { get; }

        public uint SourceNetID { get; set; }

        internal static BaseEvent Create(ByteReader reader)
        {
            var id = (EventID)reader.ReadByte();
            var sourceNetID = reader.ReadUInt32();

            if (!Lookup.ContainsKey(id))
            {
                throw new IOException($"Invalid id: {id}");
            }
            var ev = Lookup[id]();
            ev.SourceNetID = sourceNetID;
            ev.ArgsBase.Read(reader);
            return ev;
        }

        internal void Write(ByteWriter writer)
        {
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SourceNetID);
            this.ArgsBase.Write(writer);
        }

        internal static EventDict GenerateLookup()
        {
            var lookup = new EventDict();
            foreach (Type type in Assembly.GetAssembly(typeof(BaseEvent)).GetTypes())
            {
                if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(BaseEvent)) 
                    || type.IsEquivalentTo(typeof(UnknownEvent)))
                {
                    continue;
                }
                var tmp = (BaseEvent)Activator.CreateInstance(type);
                var id = tmp.ID;
                if (lookup.ContainsKey(id))
                {
                    throw new Exception("ID already in lookup map");
                }
                var lambda = Expression.Lambda<Func<BaseEvent>>(
                    Expression.New(type),
                    Array.Empty<ParameterExpression>()
                ).Compile();
                lookup.Add(id, lambda);
            }
            return lookup;
        }
        internal static readonly EventDict Lookup = GenerateLookup();
    }

    public abstract class Event<T, T2> : BaseEvent
        where T : ArgsBase, new()
    {
        public T Args { get; set; } = new T();
        public override ArgsBase ArgsBase => Args;
    }

    class UnknownEvent : Event<ArgsBase, ArgsBase>
    {
        public override EventID ID => (EventID)RawID;
        public byte RawID { get; set; }
    }
}
