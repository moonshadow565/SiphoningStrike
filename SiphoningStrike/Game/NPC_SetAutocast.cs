using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_SetAutocast : GamePacket // 0x022
    {
        public override GamePacketID ID => GamePacketID.NPC_SetAutocast;
        public byte Slot { get; set; }

        public NPC_SetAutocast() {}
        public NPC_SetAutocast(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Slot = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.Slot);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}