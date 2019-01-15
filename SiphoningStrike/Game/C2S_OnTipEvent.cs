using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_OnTipEvent : GamePacket // 0x070
    {
        public override GamePacketID ID => GamePacketID.C2S_OnTipEvent;

        public byte TipCommand { get; set; }
        public uint TipID { get; set; }

        public C2S_OnTipEvent() {}
        public C2S_OnTipEvent(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.TipCommand = reader.ReadByte();
            this.TipID = reader.ReadUInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(this.TipCommand);
            writer.WriteUInt32(this.TipID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}