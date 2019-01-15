using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_MapPing : GamePacket // 0x05A
    {
        public override GamePacketID ID => GamePacketID.C2S_MapPing;

        public Vector3 Position { get; set; }
        public uint TargetNetID { get; set; }

        public byte PingCategory { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Position = reader.ReadVector3();
            this.TargetNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(this.Position);
            writer.WriteUInt32(this.TargetNetID);

            byte bitfield = 0;
            bitfield |= (byte)(this.PingCategory & 0x0F);
            writer.WriteByte(bitfield);
        }
    }
}