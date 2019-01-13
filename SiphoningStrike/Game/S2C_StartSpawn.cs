using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_StartSpawn : GamePacket // 0x065
    {
        public override GamePacketID ID => GamePacketID.S2C_StartSpawn;

        public byte BotCountOrder { get; set; }
        public byte BotCountChaos { get; set; }

        public S2C_StartSpawn() {}
        public S2C_StartSpawn(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.BotCountOrder = reader.ReadByte();
            this.BotCountChaos = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(BotCountOrder);
            writer.WriteByte(BotCountChaos);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}