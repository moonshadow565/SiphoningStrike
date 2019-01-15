using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_PlayVOAudioEvent : GamePacket // 0x07D
    {
        public override GamePacketID ID => GamePacketID.S2C_PlayVOAudioEvent;

        public string FolderName { get; set; }
        public string EventID { get; set; }
        public byte CallbackType { get; set; }
        public uint AudioEventNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.FolderName = reader.ReadFixedString(64);
            this.EventID = reader.ReadFixedString(64);
            this.CallbackType = reader.ReadByte();
            this.AudioEventNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteFixedString(this.FolderName, 64);
            writer.WriteFixedString(this.EventID, 64);
            writer.WriteByte(this.CallbackType);
            writer.WriteUInt32(this.AudioEventNetID);
        }
    }
}