﻿using System;
using System.IO;
using System.Text;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;
using SiphoningStrike.Game.Common;

namespace SiphoningStrike
{
    internal class ByteReader
    {
        private BinaryReader _reader;
        private MemoryStream _stream;

        public ByteReader(byte[] data)
        {
            _stream = new MemoryStream(data);
            _reader = new BinaryReader(_stream);
        }

        public int Position => (int)_stream.Position;
        public int Seek(int offset, SeekOrigin origin = SeekOrigin.Current)
        {
            return (int)_stream.Seek(offset, origin);
        }
        public int Length => (int)_stream.Length;
        public int BytesLeft => (int)(_stream.Length - _stream.Position);

        public bool ReadBool() => _reader.ReadBoolean();
        public sbyte ReadSByte() => _reader.ReadSByte();
        public byte ReadByte() => _reader.ReadByte();
        public short ReadInt16() => _reader.ReadInt16();
        public ushort ReadUInt16() => _reader.ReadUInt16();
        public int ReadInt32() => _reader.ReadInt32();
        public uint ReadUInt32() => _reader.ReadUInt32();
        public long ReadInt64() => _reader.ReadInt64();
        public ulong ReadUInt64() => _reader.ReadUInt64();
        public float ReadFloat() => _reader.ReadSingle();
        public double ReadDouble() => _reader.ReadDouble();
        public float ReadF8() => (ReadByte() - 128) / 100.0f;

        public byte[] ReadBytes(int count) 
        {
            if (count > BytesLeft) 
            {
                throw new IOException($"Failed to read bytes: {count}");
            }
            return _reader.ReadBytes(count);
        }

        public void ReadPad(int count) 
        {
            if (count > BytesLeft)
            {
                throw new IOException($"Failed to read pad: {count}");
            }
            _stream.Seek(count, SeekOrigin.Current);
        }

        public byte[] ReadBytesLeft()
        {
            return _reader.ReadBytes(BytesLeft);
        }

        public Vector2 ReadVector2()
        {
            var x = ReadFloat();
            var y = ReadFloat();
            return new Vector2(x, y);
        }

        public Vector3 ReadVector3()
        {
            var x = ReadFloat();
            var y = ReadFloat();
            var z = ReadFloat();
            return new Vector3(x, y, z);
        }

        public Vector4 ReadVector4()
        {
            var x = ReadFloat();
            var y = ReadFloat();
            var z = ReadFloat();
            var w = ReadFloat();
            return new Vector4(x, y, z, w);
        }

        public string ReadFixedString(int maxLength)
        {
            var data = ReadBytes(maxLength).TakeWhile(c => c != 0).ToArray();
            return Encoding.UTF8.GetString(data);
        }

        public string ReadZeroTerminatedString()
        {
            var data = new List<byte>();
            while (true)
            {
                byte c = ReadByte();
                if (c == 0)
                {
                    break;
                }
                data.Add(c);
            }
            return Encoding.UTF8.GetString(data.ToArray());
        }

        public string ReadSizedStringWithZero()
        {
            var count = ReadInt32();
            if (count <= 0)
            {
                return "";
            }
            var data = ReadBytes(count - 1);
            ReadPad(1);
            return Encoding.UTF8.GetString(data);
        }

        public string ReadSizedString()
        {
            var count = ReadInt32();
            if (count <= 0)
            {
                return "";
            }
            var data = ReadBytes(count);
            return Encoding.UTF8.GetString(data);
        }

        public Color ReadColor()
        {
            return (Color)ReadUInt32();
        }
    }
}
