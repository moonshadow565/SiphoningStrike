using System;
using System.Collections.Generic;

namespace SiphoningStrike
{
    public sealed class UnknownPacket : BasePacket
    {
        internal override void ReadPacket(ByteReader reader) { }

        internal override void WritePacket(ByteWriter writer) { }
    }
}
