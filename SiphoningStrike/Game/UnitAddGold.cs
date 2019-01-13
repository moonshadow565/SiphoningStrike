using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UnitAddGold : GamePacket // 0x025
    {
        public override GamePacketID ID => GamePacketID.UnitAddGold;

        public uint TargetNetID { get; set; }
        public uint SourceNetID { get; set; }
        public float GoldAmmount { get; set; }

        public UnitAddGold() {}
        public UnitAddGold(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.TargetNetID = reader.ReadUInt32();
            this.SourceNetID = reader.ReadUInt32();
            this.GoldAmmount = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.TargetNetID);
            writer.WriteUInt32(this.SourceNetID);
            writer.WriteFloat(this.GoldAmmount);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}