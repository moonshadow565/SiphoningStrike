using System;
namespace SiphoningStrike
{
    public abstract class LoadScreenPacket : BasePacket
    {
        public abstract LoadScreenPacketID ID { get; }
    }
}
