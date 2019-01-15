using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class SpawnMinionS2C : GamePacket // 0x080
    {
        public override GamePacketID ID => GamePacketID.SpawnMinionS2C;

        public uint UnitNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public uint SkinID { get; set; }
        public uint CloneNetID { get; set; }
        private Bits<uint> _bitfield1;
        public uint TeamID 
        { 
            get => _bitfield1.GetUInt32(0, 9);
            set => _bitfield1.SetUInt32(0, 9, value); 
        }
        private Bits<byte> _bitfield2;
        public float VisibilitySize { get; set; }
        public bool IgnoreCollision
        {
            get => _bitfield2.GetBool(0, 1);
            set => _bitfield2.SetBool(0, 1, value);
        }
        public bool IsWard
        {
            get => _bitfield2.GetBool(1, 1);
            set => _bitfield2.SetBool(1, 1, value);
        }
        public bool UseBehaviorTreeAI
        {
            get => _bitfield2.GetBool(2, 1);
            set => _bitfield2.SetBool(2, 1, value);
        }
        public string Name { get; set; }
        public string SkinName { get; set; }

        internal override void ReadBody(ByteReader reader)
        {
            this.UnitNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.SkinID = reader.ReadUInt32();
            this.CloneNetID = reader.ReadUInt32();
            this._bitfield1 = reader.ReadBits32();
            this.VisibilitySize = reader.ReadFloat();
            this._bitfield2 = reader.ReadBits8();
            this.Name = reader.ReadFixedString(64);
            this.SkinName = reader.ReadFixedString(64);
        }
        internal override void WriteBody(ByteWriter writer)
        {
            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteVector3(this.Position);
            writer.WriteUInt32(this.SkinID);
            writer.WriteUInt32(this.CloneNetID);
            writer.WriteBits32(this._bitfield1);
            writer.WriteFloat(this.VisibilitySize);
            writer.WriteBits8(this._bitfield2);
            writer.WriteFixedString(this.Name, 64);
            writer.WriteFixedString(this.SkinName, 64);
        }
    }
}