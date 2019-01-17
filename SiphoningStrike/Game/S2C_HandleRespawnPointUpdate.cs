using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_HandleRespawnPointUpdate : GamePacket // 0x0DE
    {
        public override GamePacketID ID => GamePacketID.S2C_HandleRespawnPointUpdate;

        public byte RespawnPointCommand { get; set; }
        public byte RespawnPointUIID { get; set; }
        public uint TeamID { get; set; }
        public uint ClientID { get; set; }
        public Vector3 Position { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.RespawnPointCommand = reader.ReadByte();
            this.RespawnPointUIID = reader.ReadByte();
            this.TeamID = reader.ReadUInt32();
            this.ClientID = reader.ReadUInt32();
            this.Position = reader.ReadVector3();
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteByte(this.RespawnPointCommand);
            writer.WriteByte(this.RespawnPointUIID);
            writer.WriteUInt32(this.TeamID);
            writer.WriteUInt32(this.ClientID);
            writer.WriteVector3(this.Position);    
        }
    }
}