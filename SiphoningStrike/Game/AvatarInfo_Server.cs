using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class AvatarInfo_Server : GamePacket // 0x02C
    {
        public override GamePacketID ID => GamePacketID.AvatarInfo_Server;

        private uint[] _itemIDs = new uint[30];
        private uint[] _summonerSpellIDs = new uint[2];
        private Talent[] _talents = new Talent[80];

        public uint[] ItemIDs => _itemIDs;
        public uint[] SummonerIDs => _summonerSpellIDs;
        public uint[] SummonerIDs2 => _summonerSpellIDs;
        public Talent[] Talents => _talents;
        public byte Level { get; set; }

        public AvatarInfo_Server() {}
        public AvatarInfo_Server(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            for (var i = 0; i < this.ItemIDs.Length; i++)
            {
                this.ItemIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < this.SummonerIDs.Length; i++)
            {
                this.SummonerIDs[i] = reader.ReadUInt32();
            }
            for (var i = 0; i < this.Talents.Length; i++)
            {
                this.Talents[i] = reader.ReadTalent();
            }
            this.Level = reader.ReadByte();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            for (var i = 0; i < this.ItemIDs.Length; i++)
            {
                writer.WriteUInt32(this.ItemIDs[i]);
            }
            for (var i = 0; i < this.SummonerIDs.Length; i++)
            {
                writer.WriteUInt32(this.SummonerIDs[i]);
            }
            for (var i = 0; i < this.Talents.Length; i++)
            {
                writer.WriteTalent(this.Talents[i]);
            }
            writer.WriteByte(this.Level);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}