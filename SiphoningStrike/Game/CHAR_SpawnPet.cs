using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class CHAR_SpawnPet : GamePacket // 0x03C
    {
        public override GamePacketID ID => GamePacketID.CHAR_SpawnPet;

        public uint UnitNetID { get; set; }
        public byte UnitNetNodeID { get; set; }
        public Vector3 Position { get; set; }
        public int CastSpellLevelPlusOne { get; set; }
        public float Duration { get; set; }
        public int DamageBonus { get; set; }
        public int HealthBonus { get; set; }
        public string Name { get; set; } = "";
        public string Skin { get; set; } = "";
        public int SkinID { get; set; }
        public string BuffName { get; set; } = "";
        public uint CloneNetID { get; set; }
        public bool CopyInventory { get; set; }
        public bool ClearFocusTarget { get; set; }
        public string AIscript { get; set; } = "";
        public bool ShowMinimapIcon { get; set; }


        public CHAR_SpawnPet() {}
        public CHAR_SpawnPet(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.UnitNetID = reader.ReadUInt32();
            this.UnitNetNodeID = reader.ReadByte();
            this.Position = reader.ReadVector3();
            this.CastSpellLevelPlusOne = reader.ReadInt32();
            this.Duration = reader.ReadFloat();
            this.DamageBonus = reader.ReadInt32();
            this.HealthBonus = reader.ReadInt32();
            this.Name = reader.ReadFixedString(32);
            this.Skin = reader.ReadFixedString(32);
            this.SkinID = reader.ReadInt32();
            this.BuffName = reader.ReadFixedString(64);
            this.CloneNetID = reader.ReadUInt32();

            byte bitfield = reader.ReadByte();
            this.CopyInventory = (bitfield & 1) != 0;
            this.ClearFocusTarget = (bitfield & 2) != 0;

            this.AIscript = reader.ReadFixedStringLast(32);
            this.ShowMinimapIcon = reader.ReadBool();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteUInt32(this.UnitNetID);
            writer.WriteByte(this.UnitNetNodeID);
            writer.WriteVector3(this.Position);
            writer.WriteInt32(this.CastSpellLevelPlusOne);
            writer.WriteFloat(this.Duration);
            writer.WriteInt32(this.DamageBonus);
            writer.WriteInt32(this.HealthBonus);
            writer.WriteFixedString(this.Name, 32);
            writer.WriteFixedString(this.Skin, 32);
            writer.WriteInt32(this.SkinID);
            writer.WriteFixedString(this.BuffName, 64);
            writer.WriteUInt32(this.CloneNetID);

            byte bitfield = 0;
            if (this.CopyInventory)
                bitfield |= 1;
            if (this.ClearFocusTarget)
                bitfield |= 2;
            writer.WriteByte(bitfield);

            writer.WriteFixedStringLast(this.AIscript, 32);
            writer.WriteBool(this.ShowMinimapIcon);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}