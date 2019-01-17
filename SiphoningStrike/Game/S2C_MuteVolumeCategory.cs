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

        internal override void ReadBody(ByteReader reader)
        {
            this.VolumeCategory = reader.ReadByte();
            byte bitfield = reader.ReadByte();
            this.Mute = (bitfield & 0x01u) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(VolumeCategory);
            byte bitfield = 0;
            if (Mute)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}