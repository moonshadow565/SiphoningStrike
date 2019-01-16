using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class OnEnterLocalVisiblityClient : GamePacket // 0x0B5
    {
        public override GamePacketID ID => GamePacketID.OnEnterLocalVisiblityClient;

        public LocalVisibilityData LocalVisiblityData { get; set; } = new LocalVisibilityDataAIBase();

        internal override void ReadBody(ByteReader reader)
        {
            this.LocalVisiblityData = reader.ReadLocalVisiblityData();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteLocalVisiblityData(this.LocalVisiblityData);
        }
    }
}