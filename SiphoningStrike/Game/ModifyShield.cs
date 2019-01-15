using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class ModifyShield : GamePacket // 0x069
    {
        public override GamePacketID ID => GamePacketID.ModifyShield;

        public bool Physical { get; set; }
        public bool Magical { get; set; }
        public bool StopShieldFade { get; set; }
        public float Ammount { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            byte bitfield = reader.ReadByte();
            this.Physical = (bitfield & 1) != 0;
            this.Magical = (bitfield & 2) != 0;
            this.StopShieldFade = (bitfield & 4) != 0;

            this.Ammount = reader.ReadFloat();

        }
        internal override void WriteBody(ByteWriter writer)
        {
            byte bitfield = 0;
            if (this.Physical)
                bitfield |= 1;
            if (this.Magical)
                bitfield |= 2;
            if (this.StopShieldFade)
                bitfield |= 4;
            writer.WriteByte(bitfield);

            writer.WriteFloat(this.Ammount);

        }
    }
}