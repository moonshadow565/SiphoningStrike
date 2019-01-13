using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_MuteVolumeCategory : GamePacket // 0x029
    {
        public override GamePacketID ID => GamePacketID.S2C_MuteVolumeCategory;

        public byte VolumeCategory { get; set; }
        public bool Mute { get; set; }

        public S2C_MuteVolumeCategory() {}
        public S2C_MuteVolumeCategory(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.VolumeCategory = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.Mute = (bitfield & 0x01u) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteByte(VolumeCategory);
            byte bitfield = 0;
            if (Mute)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}