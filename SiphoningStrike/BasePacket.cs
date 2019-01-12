using System;
using System.IO;

namespace SiphoningStrike
{
    public abstract class BasePacket
    {
        public byte[] BytesLeft { get; set; } = new byte[0];

        internal BasePacket() { }

        public static BasePacket Create(byte[] data, ChannelID channel)
        {
            switch (channel)
            {
                case ChannelID.Default:
                    return new KeyCheckPacket(data);
                case ChannelID.ClientToServer:
                case ChannelID.SynchClock:
                case ChannelID.Broadcast:
                case ChannelID.BroadcastUnreliable:
                    var gameId = (GamePacketID)data[0];
                    if(gameId == GamePacketID.Batch)
                    {
                        return new BatchGamePacket(data);
                    }
                    if (GamePacketLookup.Lookup.ContainsKey(gameId))
                    {
                        return GamePacketLookup.Lookup[gameId](data);
                    }
                    return new UnknownPacket(data);
                case ChannelID.Chat:
                    return new ChatPacket(data);
                case ChannelID.LoadingScreen:
                    var loadScreenId = (LoadScreenPacketID)data[0];
                    if (LoadScreenPacketLookup.Lookup.ContainsKey(loadScreenId))
                    {
                        return LoadScreenPacketLookup.Lookup[loadScreenId](data);
                    }
                    return new UnknownPacket(data);
                default:
                    return new UnknownPacket(data);
            }
        }

        public abstract byte[] GetBytes();
    }
}
