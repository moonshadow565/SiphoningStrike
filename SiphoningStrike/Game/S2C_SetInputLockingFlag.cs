using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_SetInputLockingFlag : GamePacket // 0x089
    {
        public override GamePacketID ID => GamePacketID.S2C_SetInputLockingFlag;

        public uint InputLockingFlags { get; set; }
        public bool Value { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.InputLockingFlags = reader.ReadUInt32();
            this.Value = reader.ReadBool();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.InputLockingFlags);
            writer.WriteBool(this.Value);
        }
    }
}