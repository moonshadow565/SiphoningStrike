using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_BotAI : GamePacket // 0x015
    {
        public override GamePacketID ID => GamePacketID.S2C_BotAI;

        private string[] _states = new string[3];
        public string AIName { get; set; } = "";
        public string AIStrategy { get; set; } = "";
        public string AIBehaviour { get; set; } = "";
        public string AITask { get; set; } = "";
        public string[] States => _states;

        public S2C_BotAI() {}
        public S2C_BotAI(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.AIName = reader.ReadFixedString(64);
            this.AIStrategy = reader.ReadFixedString(64);
            this.AIBehaviour = reader.ReadFixedString(64);
            this.AITask = reader.ReadFixedString(64);
            for (var i = 0; i < this.States.Length; i++)
            {
                this.States[i] = reader.ReadFixedString(64);
            }

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteFixedString(this.AIName, 64);
            writer.WriteFixedString(this.AIStrategy, 64);
            writer.WriteFixedString(this.AIBehaviour, 64);
            writer.WriteFixedString(this.AITask, 64);
            for (var i = 0; i < this.States.Length; i++)
            {
                writer.WriteFixedString(this.States[i], 64);
            }

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}