using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_LevelUp : GamePacket // 0x045
    {
        public override GamePacketID ID => GamePacketID.NPC_LevelUp;

        public byte Level { get; set; }
        public byte AveliablePoints { get; set; }

        public NPC_LevelUp() {}
        public NPC_LevelUp(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Level = reader.ReadByte();
            this.AveliablePoints = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.Level);
            writer.WriteByte(this.AveliablePoints);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}