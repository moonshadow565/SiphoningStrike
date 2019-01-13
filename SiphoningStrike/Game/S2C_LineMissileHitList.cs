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

        public S2C_LineMissileHitList() {}
        public S2C_LineMissileHitList(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            int size = reader.ReadInt16();
            for (int i = 0; i < size; i++)
            {
                this.TargetNetIDs.Add(reader.ReadUInt32());
            }

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

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

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}