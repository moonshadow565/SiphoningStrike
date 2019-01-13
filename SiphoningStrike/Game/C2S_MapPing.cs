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

        public C2S_MapPing() {}
        public C2S_MapPing(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Position = reader.ReadVector3();
            this.TargetNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteVector3(this.Position);
            writer.WriteUInt32(this.TargetNetID);

            byte bitfield = 0;
            bitfield |= (byte)(this.PingCategory & 0x0F);
            writer.WriteByte(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}