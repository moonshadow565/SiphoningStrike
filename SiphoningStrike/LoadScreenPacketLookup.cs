using System;
using System.Collections.Generic;
using SiphoningStrike.LoadScreen;

namespace SiphoningStrike
{
    using LoadScreenDict = Dictionary<LoadScreenPacketID, Func<byte[], LoadScreenPacket>>;
    public static class LoadScreenPacketLookup
    {
        public static readonly LoadScreenDict Lookup = new LoadScreenDict
        {
            { LoadScreenPacketID.RequestJoinTeam, (d) => new RequestJoinTeam(d) },
            { LoadScreenPacketID.RequestReskin, (d) => new RequestReskin(d) },
            { LoadScreenPacketID.RequestRename, (d) => new RequestRename(d) },
            { LoadScreenPacketID.TeamRosterUpdate, (d) => new TeamRosterUpdate(d) },
        };
    }
}
