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

            ushort bitfield = reader.ReadUInt16();
            data.Ping = (ushort)(bitfield & 0x7FFF);

            byte bitfield2 = reader.ReadByte();
            data.Ready = (bitfield2 & 0x01) != 0;

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

            ushort bitfield = 0;
            bitfield |= (ushort)(data.Ping & 0x7FFF);
            writer.WriteUInt16(bitfield);

            byte bitfield2 = 0;
            if (data.Ready)
                bitfield2 |= 0x01;
            writer.WriteByte(bitfield2);
        }
    }
}
