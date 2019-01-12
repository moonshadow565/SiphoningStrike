using System;
namespace SiphoningStrike
{
    public enum ChannelID
    {
        Default             = 0x0, // Only used once for KeyCheck
        ClientToServer      = 0x1, // Game PKT
        SynchClock          = 0x2, // Game PKT
        Broadcast           = 0x3, // Game PKT
        BroadcastUnreliable = 0x4, // Game PKT
        Chat                = 0x5, // Chat packet
        LoadingScreen       = 0x6, // Payload EGP
    }
}