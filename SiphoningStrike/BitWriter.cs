using System;
using System.IO;
namespace SiphoningStrike
{
    internal class BitWriter
    {
        private ulong _buffer = 0;
        private int _index = 0;

        public void WriteU64(ulong value, int size)
        {
            if (size > (64 - _index))
            {
                throw new IOException("Failed writing bits");
            }
            _buffer |= (value & ((1uL << size) - 1)) << _index;
            _index += size;
        }

        public void WriteI64(long value, int size) => WriteU64((ulong)value, size);
        public void WriteU32(uint value, int size) => WriteU64(value, size);
        public void WriteI32(int value, int size) => WriteI64(value, size);
        public void WriteU16(ushort value, int size) => WriteU64(value, size);
        public void WriteI16(short value, int size) => WriteI64(value, size);
        public void WriteByte(byte value, int size) => WriteU64(value, size);
        public void WriteSByte(sbyte value, int size) => WriteI64(value, size);
        public void WriteBool(bool value, int size) => WriteU64(value ? 1uL : 0uL, size);

        public byte[] GetBytes(int byteCount)
        {
            if (byteCount != 1 && byteCount != 2 && byteCount != 4 && byteCount != 8)
            {
                throw new IOException("Bitpack can only be 1,2,4 or 8 bytes");
            }
            byte[] buffer = new byte[byteCount];
            byte[] bytes =  BitConverter.GetBytes(_buffer);
            Buffer.BlockCopy(bytes, 0, buffer, 0, byteCount);
            return buffer;
        }

        public void CopyTo(ByteWriter writer, int byteCount)
        {
            writer.WriteBytes(GetBytes(byteCount));
        }
    }
}
