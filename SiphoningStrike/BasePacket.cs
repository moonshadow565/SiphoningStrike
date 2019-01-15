using System;
using System.IO;

namespace SiphoningStrike
{
    public abstract class BasePacket
    {
        public byte[] BytesLeft { get; set; } = new byte[0];

        internal BasePacket() { }

        internal abstract void ReadPacket(ByteReader reader);

        public void Read(byte[] data)
        {
            var reader = new ByteReader(data);
            this.ReadPacket(reader);
            this.BytesLeft = reader.ReadBytesLeft();
        }

        private static BasePacket Construct(byte[] data, ChannelID channel)
        {
            if (data.Length == 0)
            {
                throw new IOException("Empty packet can not be packet!");
            }
            switch (channel)
            {
                case ChannelID.Default:
                    return new KeyCheckPacket();
                case ChannelID.ClientToServer:
                case ChannelID.SynchClock:
                case ChannelID.Broadcast:
                case ChannelID.BroadcastUnreliable:
                    var gameId = (GamePacketID)data[0];
                    if (gameId == GamePacketID.Batch)
                    {
                        return new BatchGamePacket();
                    }
                    if (gameId == GamePacketID.ExtendedPacket)
                    {
                        if (data.Length < 7)
                        {
                            throw new IOException("Packet too small to be extended packet!");
                        }
                        gameId = (GamePacketID)((ushort)(data[5]) | (ushort)(data[6] << 8));
                    }
                    if (GamePacketLookup.Lookup.ContainsKey(gameId))
                    {
                        return GamePacketLookup.Lookup[gameId]();
                    }
                    return new UnknownPacket();
                case ChannelID.Chat:
                    return new ChatPacket();
                case ChannelID.LoadingScreen:
                    var loadScreenId = (LoadScreenPacketID)data[0];
                    if (LoadScreenPacketLookup.Lookup.ContainsKey(loadScreenId))
                    {
                        return LoadScreenPacketLookup.Lookup[loadScreenId]();
                    }
                    return new UnknownPacket();
                default:
                    return new UnknownPacket();
            }
        }

        public static BasePacket Create(byte[] data, ChannelID channel)
        {
            var result = Construct(data, channel);
            result.Read(data);
            return result;
        }

        internal abstract void WritePacket(ByteWriter writer);

        public byte[] GetBytes()
        {
            var writer = new ByteWriter();
            this.WritePacket(writer);
            writer.WriteBytes(this.BytesLeft);
            return writer.GetBytes();
        }
    }
}
