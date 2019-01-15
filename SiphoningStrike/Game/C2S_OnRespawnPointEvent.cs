using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_OnRespawnPointEvent : GamePacket // 0x0DF
    {
        public override GamePacketID ID => GamePacketID.C2S_OnRespawnPointEvent;

        public byte RespawnPointEvent { get; set; }
        public byte RespawnPointUIElementID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.RespawnPointEvent = reader.ReadByte();
            this.RespawnPointUIElementID = reader.ReadByte();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.RespawnPointEvent);
            writer.WriteByte(this.RespawnPointUIElementID);
        }
    }
}