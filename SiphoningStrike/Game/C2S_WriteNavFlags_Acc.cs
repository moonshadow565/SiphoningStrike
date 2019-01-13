using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_WriteNavFlags_Acc : GamePacket // 0x020
    {
        public override GamePacketID ID => GamePacketID.C2S_WriteNavFlags_Acc;

        public int SyncID { get; set; }

        public C2S_WriteNavFlags_Acc() {}
        public C2S_WriteNavFlags_Acc(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.SyncID = reader.ReadInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteInt32(this.SyncID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}