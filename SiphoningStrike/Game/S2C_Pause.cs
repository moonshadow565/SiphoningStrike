using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_Pause : GamePacket // 0x033
    {
        public override GamePacketID ID => GamePacketID.S2C_Pause;

        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public int SyncID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.Position = reader.ReadVector3();
            this.Forward = reader.ReadVector3();
            this.SyncID = reader.ReadInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteVector3(this.Position);
            writer.WriteVector3(this.Forward);
            writer.WriteInt32(this.SyncID);
        }
    }
}