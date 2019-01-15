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

        public S2C_AI_TargetSelection() {}
        public S2C_AI_TargetSelection(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            for (var i = 0; i < this.TargetNetIDs.Length; i++)
            {
                this.TargetNetIDs[i] = reader.ReadUInt32();
            }

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            for (var i = 0; i < this.TargetNetIDs.Length; i++)
            {
                writer.WriteUInt32(this.TargetNetIDs[i]);
            }

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}