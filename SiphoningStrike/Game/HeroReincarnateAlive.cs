using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class HeroReincarnateAlive : GamePacket // 0x031
    {
        public override GamePacketID ID => GamePacketID.HeroReincarnateAlive;

        public Vector3 Position { get; set; }

        public HeroReincarnateAlive() {}
        public HeroReincarnateAlive(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.Position = reader.ReadVector3();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteVector3(this.Position);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}