using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ChangeCharacterData : GamePacket // 0x09F
    {
        public override GamePacketID ID => GamePacketID.S2C_ChangeCharacterData;

        public uint StackID { get; set; }
        public bool UseSpells { get; set; }
        public string SkinName { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.StackID = reader.ReadUInt32();
            this.UseSpells = reader.ReadBool();
            this.SkinName = reader.ReadFixedStringLast(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.StackID);
            writer.WriteBool(this.UseSpells);
            writer.WriteFixedStringLast(this.SkinName, 64);
        }
    }
}