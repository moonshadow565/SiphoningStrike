using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_AI_TargetSelection : GamePacket // 0x06C
    {
        public override GamePacketID ID => GamePacketID.S2C_AI_TargetSelection;

        private uint[] _targetNetIds = new uint[5];

        public uint[] TargetNetIDs => _targetNetIds;

        internal override void ReadBody(ByteReader reader)
        {
            for (var i = 0; i < this.TargetNetIDs.Length; i++)
            {
                this.TargetNetIDs[i] = reader.ReadUInt32();
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            for (var i = 0; i < this.TargetNetIDs.Length; i++)
            {
                writer.WriteUInt32(this.TargetNetIDs[i]);
            }
        }
    }
}