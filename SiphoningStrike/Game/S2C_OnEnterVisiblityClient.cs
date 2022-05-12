using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_OnEnterVisiblityClient : GamePacket // 0x0C2
    {
        public override GamePacketID ID => GamePacketID.S2C_OnEnterVisiblityClient;

        public List<ItemData> Items { get; set; } = new List<ItemData>();
        public byte LookAtType { get; set; }
        public Vector3 LookAtPosition { get; set; }
        public MovementData MovementData { get; set; } = new MovementDataNone();


        internal override void ReadBody(ByteReader reader)
        {
            if(reader.BytesLeft < 2)
            {
                reader.ReadPad(1);
                return;
            }
            byte itemCount = reader.ReadByte();
            for (int i = 0; i < itemCount; i++)
            {
                var item = new ItemData();
                item.Slot = reader.ReadByte();
                item.ItemsInSlot = reader.ReadByte();
                item.SpellCharges = reader.ReadByte();
                item.ItemID = reader.ReadUInt32();
                this.Items.Add(item);
            }
            this.LookAtType = reader.ReadByte();
            if(this.LookAtType != 0)
            {
                this.LookAtPosition = reader.ReadVector3();
            }
            if (reader.BytesLeft < 1)
            {
                return;
            }
            this.MovementData = reader.ReadMovementDataWithHeader();
        }

        internal override void WriteBody(ByteWriter writer)
        {
            int itemCount = this.Items.Count;
            if (itemCount > 0xFF)
            {
                throw new IOException("More than 255 items!");
            }
            writer.WriteByte((byte)itemCount);
            foreach (var item in this.Items)
            {
                writer.WriteByte(item.Slot);
                writer.WriteByte(item.ItemsInSlot);
                writer.WriteByte(item.SpellCharges);
                writer.WriteUInt32(item.ItemID);
            }
            writer.WriteByte(this.LookAtType);
            if(this.LookAtType != 0)
            {
                writer.WriteVector3(this.LookAtPosition);
            }
            writer.WriteMovementDataWithHeader(this.MovementData);
        }


        public class ItemData
        {
            public byte Slot { get; internal set; }
            public byte ItemsInSlot { get; internal set; }
            public byte SpellCharges { get; internal set; }
            public uint ItemID { get; internal set; }
        }
    }
}