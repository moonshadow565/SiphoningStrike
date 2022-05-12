using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class NPC_IssueOrderReq : GamePacket // 0x075
    {
        public override GamePacketID ID => GamePacketID.C2S_NPC_IssueOrderReq;

        public byte OrderType { get; set; }
        public Vector3 Position { get; set; }
        public uint TargetNetID { get; set; }
        public MovementDataNormal MovementData { get; set; } = new MovementDataNormal();

        internal override void ReadBody(ByteReader reader)
        {
            this.OrderType = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.TargetNetID = reader.ReadUInt32();
            if(reader.BytesLeft >= 5)
            {
                this.MovementData = new MovementDataNormal(reader, 0);
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.OrderType);
            writer.WriteVector3(this.Position);
            writer.WriteUInt32(this.TargetNetID);
            if(MovementData != null)
            {
                this.MovementData.Write(writer);
            }
        }
    }
}