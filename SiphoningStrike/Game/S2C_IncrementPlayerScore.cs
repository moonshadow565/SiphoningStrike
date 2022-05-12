using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_IncrementPlayerScore : GamePacket // 0x0E2
    {
        public override GamePacketID ID => GamePacketID.S2C_IncrementPlayerScore;

        public uint PlayerNetID { get; set; }
        public byte ScoreCategory { get; set; }
        public byte ScoreEvent { get; set; }
        public bool IsCallout { get; set; }
        public float PointValue { get; set; }
        public float TotalPointValue { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.PlayerNetID = reader.ReadUInt32();
            this.ScoreCategory = reader.ReadByte();
            this.ScoreEvent = reader.ReadByte();
            this.IsCallout = (reader.ReadByte() & 1) != 0;
            this.PointValue = reader.ReadFloat();
            this.TotalPointValue = reader.ReadFloat();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.PlayerNetID);
            writer.WriteByte(this.ScoreCategory);
            writer.WriteByte(this.ScoreEvent);
            writer.WriteByte((byte)(this.IsCallout ? 1 : 0));
            writer.WriteFloat(this.PointValue);
            writer.WriteFloat(this.TotalPointValue);
        }
    }
}