using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_CreateNeutral : GamePacket // 0x066
    {
        public override GamePacketID ID => GamePacketID.S2C_CreateNeutral;

        public uint UnitNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 GroupPosition { get; set; }
        public Vector3 FaceDirectionPosition { get; set; }
        public string Name { get; set; } = "";
        public string SkinName { get; set; } = "";
        public string UniqueName { get; set; } = "";
        public string SpawnAnimationName { get; set; } = "";
        public uint TeamID { get; set; }
        public int DamageBonus { get; set; }
        public int HealthBonus { get; set; }
        public int RoamState { get; set; }
        public int GroupNumber { get; set; }
        public bool BehaviorTree { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.GroupPosition = reader.ReadVector3();
            this.FaceDirectionPosition = reader.ReadVector3();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
            this.UniqueName = reader.ReadFixedString(64);
            this.SpawnAnimationName = reader.ReadFixedString(64);
            this.TeamID = reader.ReadUInt32();
            this.DamageBonus = reader.ReadInt32();
            this.HealthBonus = reader.ReadInt32();
            this.RoamState = reader.ReadInt32();
            this.GroupNumber = reader.ReadInt32();

            byte bitfield = 0;
            this.BehaviorTree = (bitfield & 0x01) != 0;
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteVector3(this.Position);
            writer.WriteVector3(this.GroupPosition);
            writer.WriteVector3(this.FaceDirectionPosition);
            writer.WriteFixedString(this.Name, 64);
            writer.WriteFixedString(this.SkinName, 64);
            writer.WriteFixedString(this.UniqueName, 64);
            writer.WriteFixedString(this.SpawnAnimationName, 64);
            writer.WriteUInt32(this.TeamID);
            writer.WriteInt32(this.DamageBonus);
            writer.WriteInt32(this.HealthBonus);
            writer.WriteInt32(this.RoamState);
            writer.WriteInt32(this.GroupNumber);

            byte bitfield = 0;
            if (this.BehaviorTree)
                bitfield |= 0x01;
            writer.WriteByte(bitfield);
        }
    }
}