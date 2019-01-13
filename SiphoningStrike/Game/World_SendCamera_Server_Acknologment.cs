using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class World_SendCamera_Server_Acknologment : GamePacket // 0x02E
    {
        public override GamePacketID ID => GamePacketID.World_SendCamera_Server_Acknologment;
        public SByte SyncID { get; set; }

        public World_SendCamera_Server_Acknologment() {}
        public World_SendCamera_Server_Acknologment(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.SyncID = reader.ReadSByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteSByte(this.SyncID);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}