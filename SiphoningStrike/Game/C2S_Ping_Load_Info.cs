using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class C2S_Ping_Load_Info : GamePacket // 0x019
    {
        public override GamePacketID ID => GamePacketID.C2S_Ping_Load_Info;
        public ConnectionInfo ConnectionInfo { get; set; } = new ConnectionInfo();

        public C2S_Ping_Load_Info() {}
        public C2S_Ping_Load_Info(byte[] data)
        {
            var reader = new ByteReader(data);
            
            reader.ReadByte();
            this.SenderNetID = reader.ReadUInt32();

            this.ConnectionInfo = reader.ReadConnectionInfo();

            this.BytesLeft = reader.ReadBytesLeft();
        }
        public override byte[] GetBytes()
        {
            var writer = new ByteWriter();
            
            writer.WriteByte((byte)this.ID);
            writer.WriteUInt32(this.SenderNetID);

            writer.WriteConnectionInfo(this.ConnectionInfo);

            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}