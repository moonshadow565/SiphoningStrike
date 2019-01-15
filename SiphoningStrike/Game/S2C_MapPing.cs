using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_MapPing : GamePacket // 0x046
    {
        public override GamePacketID ID => GamePacketID.S2C_MapPing;

        public Vector3 Position { get; set; }
        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }

        public byte PingCategory { get; set; }
        public bool PlayAudio { get; set; }
        public bool ShowChat { get; set; }
        public bool PingThrottled { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Position = reader.ReadVector3();
            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.PingCategory = (byte)(bitfield & 0x0F);
            this.PlayAudio = (bitfield & 0x10) != 0;
            this.ShowChat = (bitfield & 0x20) != 0;
            this.PingThrottled = (bitfield & 0x40) != 0;

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(this.Position);
            writer.WriteUInt32(this.TargetNetID);
            writer.WriteUInt32(this.SourceNetID);

            byte bitfield = 0;
            bitfield |= (byte)(this.PingCategory & 0x0F);
            if (PlayAudio)
                bitfield |= 0x10;
            if (ShowChat)
                bitfield |= 0x20;
            if (PingThrottled)
                bitfield |= 0x40;
            writer.WriteByte(bitfield);

        }
    }
}