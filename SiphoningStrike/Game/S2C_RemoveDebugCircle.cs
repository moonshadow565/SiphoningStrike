using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_RemoveDebugCircle : GamePacket // 0x05B
    {
        public override GamePacketID ID => GamePacketID.S2C_RemoveDebugCircle;

        public int DebugID { get; set; }

        public S2C_RemoveDebugCircle() {}
        public S2C_RemoveDebugCircle(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.DebugID = reader.ReadInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteInt32(this.DebugID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}