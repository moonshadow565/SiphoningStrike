using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_TeamSurrenderCountDown : GamePacket // 0x016
    {
        public override GamePacketID ID => GamePacketID.S2C_TeamSurrenderCountDown;

        public float TimeRemaining { get; set; }

        public S2C_TeamSurrenderCountDown() {}
        public S2C_TeamSurrenderCountDown(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.TimeRemaining = reader.ReadFloat();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteFloat(this.TimeRemaining);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}