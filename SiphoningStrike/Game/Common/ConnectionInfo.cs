using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace SiphoningStrike.Game.Common
{
    public class ConnectionInfo
    {
        public uint ClientID { get; set; }
        public ulong PlayerID { get; set; }
        public float Percentage { get; set; }
        public float ETA { get; set; }
        public short Count { get; set; }
        public ushort Ping { get; set; }
        public bool Ready { get; set; }
    }

    static class ConnectionInfoExtension
    {
        public static ConnectionInfo ReadConnectionInfo(this ByteReader reader)
        {
            var data = new ConnectionInfo();
            data.ClientID = reader.ReadUInt32();
            data.PlayerID = reader.ReadUInt64();
            data.Percentage = reader.ReadFloat();
            data.ETA = reader.ReadFloat();
            data.Count = reader.ReadInt16();
            data.Ping = (ushort)(reader.ReadUInt16() & 0x7FFF);
            data.Ready = (reader.ReadByte() & 1) != 0;
            return data;
        }

        public static void WriteConnectionInfo(this ByteWriter writer, ConnectionInfo data)
        {
            if (data == null)
            {
                data = new ConnectionInfo();
            }

            writer.WriteUInt32(data.ClientID);
            writer.WriteUInt64(data.PlayerID);
            writer.WriteFloat(data.Percentage);
            writer.WriteFloat(data.ETA);
            writer.WriteInt16(data.Count);
            writer.WriteUInt16((ushort)(data.Ping & 0x7FFF));
            writer.WriteByte((byte)(data.Ready ? 1 : 0));
        }
    }
}
