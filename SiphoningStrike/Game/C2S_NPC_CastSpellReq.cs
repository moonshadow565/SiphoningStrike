using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_NPC_CastSpellReq : GamePacket // 0x0A2
    {
        public override GamePacketID ID => GamePacketID.C2S_NPC_CastSpellReq;

        public bool IsSummonerSpellSlot { get; set; }
        public byte Slot { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 EndPosition { get; set; }
        public uint TargetNetID { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.IsSummonerSpellSlot = (bitfield & 0x01) != 0;
            this.Slot = (byte)((bitfield >> 1) & 0x7F);

            this.Position = reader.ReadVector3();
            this.EndPosition = reader.ReadVector3();
            this.TargetNetID = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (this.IsSummonerSpellSlot)
                bitfield |= 0x01;
            bitfield |= (byte)((this.Slot & 0x7F) << 1);
            writer.WriteByte(bitfield);

            writer.WriteVector3(this.Position);
            writer.WriteVector3(this.EndPosition);
            writer.WriteUInt32(this.TargetNetID);   
        }
    }
}