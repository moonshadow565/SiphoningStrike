using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ChainMissileSync : GamePacket // 0x06F
    {
        public override GamePacketID ID => GamePacketID.S2C_ChainMissileSync;

        private uint[] _targetNetIDs = new uint[32];
        public int TargetCount { get; set; }
        public uint OwnerNetworkID { get; set; }
        public uint[] TargetNetIDs => _targetNetIDs;

        internal override void ReadBody(ByteReader reader)
        {
            this.TargetCount = reader.ReadInt32();
            this.OwnerNetworkID = reader.ReadUInt32();
            var left = reader.BytesLeft;

            //NOTE: rito plz...
            var toread = this.TargetCount;
            if (left > (toread * 4) && left == (this.TargetNetIDs.Length * 4))
            {
                toread = this.TargetNetIDs.Length;
            }

            for (var i = 0; i < toread; i++)
                this.TargetNetIDs[i] = reader.ReadUInt32();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteInt32(TargetCount);
            writer.WriteUInt32(OwnerNetworkID);
            for (var i = 0; i < this.TargetNetIDs.Length; i++)
                writer.WriteUInt32(this.TargetNetIDs[i]);
        }
    }
}