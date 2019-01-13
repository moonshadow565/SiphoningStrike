using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class OnLeaveVisiblityClient : GamePacket // 0x054
    {
        public override GamePacketID ID => GamePacketID.OnLeaveVisiblityClient;
        public OnLeaveVisiblityClient() {}
        public OnLeaveVisiblityClient(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}