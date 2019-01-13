using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_StartGame : GamePacket // 0x05F
    {
        public override GamePacketID ID => GamePacketID.S2C_StartGame;

        public bool TournamentPauseEnabled { get; set; }

        public S2C_StartGame() {}
        public S2C_StartGame(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.TournamentPauseEnabled |= (bitfield & 1) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            byte bitfield = 0;
            if (this.TournamentPauseEnabled)
                bitfield |= 1;
            writer.WriteByte(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}