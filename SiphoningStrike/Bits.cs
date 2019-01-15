using System;
namespace SiphoningStrike
{
    struct Bits<B>
    {
        public ulong _buffer;

        public Bits(ulong data)
        {
            _buffer = data;
        }
        public ulong GetUInt64(int pos, int size)
        {
            return (_buffer >> pos) & ((1uL << size) - 1uL);
        }
        public long GetInt64(int pos, int size)
        {
            return ((long)(GetUInt64(pos, size)) << (64 - size)) >> (64 - size);
        }
        public uint GetUInt32(int pos, int size) => (uint)GetUInt64(pos, size);
        public int GetInt32(int pos, int size) => (int)GetInt64(pos, size);
        public ushort GetUInt16(int pos, int size) => (ushort)GetUInt64(pos, size);
        public short GetInt16(int pos, int size) => (short)GetInt64(pos, size);
        public byte GetByte(int pos, int size) => (byte)GetUInt64(pos, size);
        public sbyte GetSByte(int pos, int size) => (sbyte)GetInt64(pos, size);
        public bool GetBool(int pos, int size) => GetUInt64(pos, size) != 0uL;
        public bool GetFlag(int pos) => (_buffer & (1uL << pos)) != 0uL;

        public void SetUInt64(int pos, int size, ulong value)
        {
            ulong mask = ((1uL << size) -1uL);
            _buffer &= ((value & mask) << pos) | ~(mask << pos);
        }
        public void SetInt64(int pos, int size, long val) => SetUInt64(pos, size, (ulong)val);
        public void SetUInt32(int pos, int size, uint val) => SetUInt64(pos, size, (ulong)val);
        public void SetInt32(int pos, int size, int val) => SetUInt64(pos, size, (ulong)val);
        public void SetUInt16(int pos, int size, ushort val) => SetUInt64(pos, size, (ulong)val);
        public void SetInt16(int pos, int size, short val) => SetUInt64(pos, size, (ulong)val);
        public void SetByte(int pos, int size, byte val) => SetUInt64(pos, size, (ulong)val);
        public void SetSByte(int pos, int size, sbyte val) => SetUInt64(pos, size, (ulong)val);
        public void SetBool(int pos, int size, bool val) => SetUInt64(pos, size, val ? 1uL : 0uL);
        public void SetFlag(int pos, bool val) 
        {
            _buffer &= ((val ? 1uL : 0uL) << pos) | ~(1uL << pos);
        }
    }
}
