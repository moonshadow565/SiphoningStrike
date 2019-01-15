using System;
using System.Collections.Generic;
using SiphoningStrike.LoadScreen;

namespace SiphoningStrike
{
    using LoadScreenDict = Dictionary<LoadScreenPacketID, Func<LoadScreenPacket>>;
    public static class LoadScreenPacketLookup
    {
        public static readonly LoadScreenDict Lookup = new LoadScreenDict
        {
            { LoadScreenPacketID.RequestJoinTeam, () => new RequestJoinTeam() },
            { LoadScreenPacketID.RequestReskin, () => new RequestReskin() },
            { LoadScreenPacketID.RequestRename, () => new RequestRename() },
            { LoadScreenPacketID.TeamRosterUpdate, () => new TeamRosterUpdate() },
        };
    }
}
