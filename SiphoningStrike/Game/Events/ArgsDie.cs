using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Events
{
    public class ArgsDie : ArgsBase
    {
        private uint[] _assists = new uint[12];
        public float GoldGiven { get; set; }
        public int AssistCount { get; set; }
        public uint[] Assists => _assists;

        internal override void Read(ByteReader reader)
        {
            base.Read(reader);
            this.GoldGiven = reader.ReadFloat();
            this.AssistCount = reader.ReadInt32();
            for (var i = 0; i < this.Assists.Length; i++)
            {
                this.Assists[i] = reader.ReadUInt32();
            }
        }
        internal override void Write(ByteWriter writer)
        {
            base.Write(writer);
            writer.WriteFloat(this.GoldGiven);
            writer.WriteInt32(this.AssistCount);
            for (var i = 0; i < this.Assists.Length; i++)
            {
                writer.WriteUInt32(this.Assists[i]);
            }
        }
    }
}
