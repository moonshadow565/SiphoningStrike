using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_WriteNavFlags : GamePacket // 0x047
    {
        public override GamePacketID ID => GamePacketID.S2C_WriteNavFlags;

        public int SyncID { get; set; }
        public List<NavFlagCricle> NavFlagCricles { get; set; } = new List<NavFlagCricle>();

        internal override void ReadBody(ByteReader reader)
        {
            this.SyncID = reader.ReadInt32();
            int size = reader.ReadInt16();
            for (var i = 0; i < size; i += 16)
            {
                this.NavFlagCricles.Add(reader.ReadNavFlagCricle());
            }

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(this.SyncID);
            int size = NavFlagCricles.Count * 16;
            if (size > 0xFFFF)
            {
                throw new IOException("NavFlagCircles list too big!");
            }
            for (int i = 0; i < this.NavFlagCricles.Count; i++)
            {
                writer.WriteNavFlagCricle(this.NavFlagCricles[i]);
            }

        }
    }
}