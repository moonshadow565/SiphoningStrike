using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Basic_Attack : GamePacket // 0x00D
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack;

        public BasicAttackData BasicAttackData { get; set; } = new BasicAttackData();
        public Basic_Attack() {}
        public Basic_Attack(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.BasicAttackData = new BasicAttackData(reader);

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            this.BasicAttackData.Write(writer);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}