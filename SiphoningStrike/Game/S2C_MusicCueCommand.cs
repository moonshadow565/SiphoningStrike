using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_MusicCueCommand : GamePacket // 0x0E5
    {
        public override GamePacketID ID => GamePacketID.S2C_MusicCueCommand;

        public byte MusicCueCommand { get; set; }
        public uint CueID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.MusicCueCommand = reader.ReadByte();
            this.CueID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.MusicCueCommand);
            writer.WriteUInt32(this.CueID);
        }
    }
}