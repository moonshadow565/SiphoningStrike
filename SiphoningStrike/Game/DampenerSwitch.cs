using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class DampenerSwitch : GamePacket // 0x02D
    {
        public override GamePacketID ID => GamePacketID.DampenerSwitch;

        public ushort Duration { get; set; }
        public bool State { get; set; }

        public DampenerSwitch() {}
        public DampenerSwitch(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            ushort bitfield = reader.ReadUInt16();
            this.Duration = (ushort)(bitfield & 0x7FFF);
            this.State = (bitfield & 0x8000) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            ushort bitfield = 0;
            bitfield |= (ushort)(this.Duration & 0x7FFF);
            if (this.State)
                bitfield |= 0x8000;
            writer.WriteUInt16(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}