using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Basic_Attack_Pos : GamePacket // 0x01D
    {
        public override GamePacketID ID => GamePacketID.Basic_Attack_Pos;

        public BasicAttackData BasicAttackData { get; set; } = new BasicAttackData();
        public Vector2 Position { get; set; }

        public Basic_Attack_Pos() {}
        public Basic_Attack_Pos(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.BasicAttackData = reader.ReadBasicAttackData();
            this.Position = reader.ReadVector2();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteBasicAttackData(this.BasicAttackData);
            writer.WriteVector2(this.Position);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}