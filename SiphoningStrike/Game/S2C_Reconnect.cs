using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_Reconnect : GamePacket // 0x010
    {
        public override GamePacketID ID => GamePacketID.S2C_Reconnect;
        public uint ClientID { get; set; }

        public S2C_Reconnect() {}
        public S2C_Reconnect(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.ClientID = reader.ReadUInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.ClientID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}