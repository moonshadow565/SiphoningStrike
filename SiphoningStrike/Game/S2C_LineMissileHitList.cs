using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_LineMissileHitList : GamePacket // 0x028
    {
        public override GamePacketID ID => GamePacketID.S2C_LineMissileHitList;

        public List<uint> TargetNetIDs { get; set; } = new List<uint>();

        internal override void ReadBody(ByteReader reader)
        {
            int size = reader.ReadInt16();
            for (int i = 0; i < size; i++)
            {
                this.TargetNetIDs.Add(reader.ReadUInt32());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            int size = this.TargetNetIDs.Count;
            if (size > 0x7FFF)
            {
                throw new IOException("Target list too big!");
            }
            writer.WriteInt16((short)size);
            for (int i = 0; i < size; i++)
            {
                writer.WriteUInt32(this.TargetNetIDs[i]);
            }
        }
    }
}