using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_Hero_Die : GamePacket // 0x061
    {
        public override GamePacketID ID => GamePacketID.NPC_Hero_Die;

        public DeathData DeathData { get; set; } = new DeathData();

        public NPC_Hero_Die() {}
        public NPC_Hero_Die(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.DeathData = reader.ReadDeathData();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteDeathData(this.DeathData);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}