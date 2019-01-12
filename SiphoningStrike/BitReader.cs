using System;
using System.IO;

namespace SiphoningStrike
{
    internal class BitReader
    {
        private ulong _buffer = 0;
        private int _index;


        public BitReader(ulong buffer)
        {
            _buffer = buffer;
            _index = 64;
        }

        public BitReader(long buffer) : this((ulong)buffer) {}

        public BitReader(ByteReader reader, int byteCount)
        {
            if (byteCount != 1 && byteCount != 2 && byteCount != 4 && byteCount != 8)
            {
                throw new IOException("Bitpack can only be 1,2,4 or 8 bytes");
            }
            var buffer = new byte[8];
            var bytes = reader.ReadBytes(byteCount);
            Buffer.BlockCopy(bytes, 0, buffer, 0, byteCount);
            _buffer = BitConverter.ToUInt64(buffer, 0);
            _index = byteCount * 8;
        }

        public ulong ReadU64(int size)
        {
            if(size > _index)
            {
                throw new IOException("Failed reading bits");
            }
            var result = _buffer & ((1uL << size) - 1);
            _buffer >>= size;
            _index -= 1;
            return result;
        }

        public long ReadI64(int size)
        {
            return (long)(ReadU64(size)) << (64 - size) >> (64 - size);
        }

        public uint ReadU32(int size) => (uint)ReadU64(size);
        public int ReadI32(int size) => (int)ReadI64(size);
        public short ReadU16(int size) => (short)ReadU64(size);
        public ushort ReadI16(int size) => (ushort)ReadI64(size);
        public sbyte ReadSByte(int size) => (sbyte)ReadU64(size);
        public byte ReadByte(int size) => (byte)ReadI64(size);
        public bool ReadBool(int size) => ReadU64(size) != 0;
        public void ReadPad(int size) => ReadU64(size);
        public bool ReadBoolBit() => ReadU64(1) != 0uL;
    }
}
