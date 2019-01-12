using System;
namespace SiphoningStrike
{
    public abstract class GamePacket : BasePacket
    {
        public abstract GamePacketID ID { get; }
        public uint SenderNetID { get; set; }
    }
}
