using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HandleCapturePointUpdate : GamePacket // 0x0DC
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleCapturePointUpdate;
        public S2C_HandleCapturePointUpdate() {}
        public S2C_HandleCapturePointUpdate(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            throw new NotImplementedException();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            throw new NotImplementedException();

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}