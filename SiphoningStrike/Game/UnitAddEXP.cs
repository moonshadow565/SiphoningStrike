using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UnitAddEXP : GamePacket // 0x011
    {
        public override GamePacketID ID => GamePacketID.UnitAddEXP;
        public uint TargetNetID { get; set; }
        public float ExpAmmount { get; set; }


        public UnitAddEXP() {}
        public UnitAddEXP(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.TargetNetID = reader.ReadUInt32();
            this.ExpAmmount = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.TargetNetID);
            writer.WriteFloat(this.ExpAmmount);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}