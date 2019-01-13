using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_PlayEmote : GamePacket // 0x04C
    {
        public override GamePacketID ID => GamePacketID.C2S_PlayEmote;

        public uint EmoteID { get; set; }

        public C2S_PlayEmote() {}
        public C2S_PlayEmote(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.EmoteID = reader.ReadUInt32();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.EmoteID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}