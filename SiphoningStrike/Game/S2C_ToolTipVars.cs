using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike.Game
{
    public sealed class S2C_ToolTipVars : GamePacket // 0x083
    {
        public override GamePacketID ID => GamePacketID.S2C_ToolTipVars;

        public List<TooltipVars> TooltipVarsList { get; set; } = new List<TooltipVars>();

        internal override void ReadBody(ByteReader reader)
        {
            int size = reader.ReadUInt16();
            for (var i = 0; i < size; i++)
            {
                this.TooltipVarsList.Add(reader.ReadTooltipVars());
            }
        }
        internal override void WriteBody(ByteWriter writer)
        {
            int size = this.TooltipVarsList.Count;
            if (size > 0xFFFF)
            {
                throw new IOException("Tooltips list too big!");
            }
            writer.WriteUInt16((ushort)size);
            for (int i = 0; i < size; i++)
            {
                writer.WriteTooltipVars(this.TooltipVarsList[i]);
            }
        }
    }
}