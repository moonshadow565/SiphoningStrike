using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Common
{
    public class PlayerLoadInfo
    {
        public ulong PlayerID { get; set; } = 0xFFFFFFFFFFFFFFFF; // -1
        public ushort SummonorLevel { get; set; }
        public uint SummonorSpell1 { get; set; }
        public uint SummonorSpell2 { get; set; }
        public bool IsBot { get; set; }
        public uint TeamId { get; set; }
        public string BotName { get; set; } = "";
        public string BotSkinName { get; set; } = "";
        public int BotDifficulty { get; set; }
        public int ProfileIconId { get; set; }
    }

    static class PlayerLoadInfoExtension
    {
        public static PlayerLoadInfo ReadPlayerInfo(this ByteReader reader)
        {
            var data = new PlayerLoadInfo();
            data.PlayerID = reader.ReadUInt64();
            data.SummonorLevel = reader.ReadUInt16();
            data.SummonorSpell1 = reader.ReadUInt32();
            data.SummonorSpell2 = reader.ReadUInt32();
            data.IsBot = reader.ReadBool();
            data.TeamId = reader.ReadUInt32();
            reader.ReadPad(28);//data.BotName = reader.ReadFixedString(64);
            reader.ReadPad(28);//data.BotSkinName = reader.ReadFixedString(64);
            data.BotDifficulty = reader.ReadInt32();
            data.ProfileIconId = reader.ReadInt32();
            return data;
        }

        public static void WritePlayerInfo(this ByteWriter writer, PlayerLoadInfo data)
        {
            if (data == null)
            {
                data = new PlayerLoadInfo();
            }
            writer.WriteUInt64(data.PlayerID);
            writer.WriteUInt16(data.SummonorLevel);
            writer.WriteUInt32(data.SummonorSpell1);
            writer.WriteUInt32(data.SummonorSpell2);
            writer.WriteBool(data.IsBot);
            writer.WriteUInt32(data.TeamId);
            writer.WritePad(28);//writer.WriteFixedString(data.BotName, 64);
            writer.WritePad(28);//writer.WriteFixedString(data.BotSkinName, 64);
            writer.WriteInt32(data.BotDifficulty);
            writer.WriteInt32(data.ProfileIconId);
        }
    }
}
