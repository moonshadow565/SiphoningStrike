using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_World_LockCamera_Server : GamePacket // 0x086
    {
        public override GamePacketID ID => GamePacketID.C2S_World_LockCamera_Server;

        public bool Locked { get; set; }
        public uint ClientID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Locked = reader.ReadBool();
            this.ClientID = reader.ReadUInt32();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteBool(this.Locked);
            writer.WriteUInt32(this.ClientID);
        }
    }
}