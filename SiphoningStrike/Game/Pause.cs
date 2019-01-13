using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class Pause : GamePacket // 0x033
    {
        public override GamePacketID ID => GamePacketID.Pause;

        public uint ClientID { get; set; }
        public int PauseTimeRemaining { get; set; }
        public bool IsTournamentPause { get; set; }

        public Pause() {}
        public Pause(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.ClientID = reader.ReadUInt32();
            this.PauseTimeRemaining = reader.ReadInt32();

            byte bitfield = reader.ReadByte();
            this.IsTournamentPause = (bitfield & 0x01) != 0;

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.ClientID);
            writer.WriteInt32(this.PauseTimeRemaining);

            byte bitfield = 0;
            if (this.IsTournamentPause)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}