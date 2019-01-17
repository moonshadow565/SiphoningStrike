using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class UpdateLevelPropS2C : GamePacket // 0x0DA
    {
        public override GamePacketID ID => GamePacketID.UpdateLevelPropS2C;

        public UpdateLevelPropData UpdateLevelPropData { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UpdateLevelPropData = reader.ReadUpdateLevelPropData();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUpdateLevelPropData(this.UpdateLevelPropData);
        }
    }
}