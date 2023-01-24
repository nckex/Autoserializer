﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutoSerializer.Definitions
{
    public static class MemoryStreamExtensions
    {
        public static void ExSkip(this MemoryStream stream, in int size)
        {
            for (var i = 0; i < size; i++)
                stream.WriteByte(0);
        }

        public static void ExWrite(this MemoryStream stream, in bool value)
        {
            stream.WriteByte(value ? (byte)1 : (byte)0);
        }

        public static void ExWrite(this MemoryStream stream, in byte value)
        {
            stream.WriteByte(value);
        }

        public static void ExWrite(this MemoryStream stream, in sbyte value)
        {
            stream.WriteByte((byte)value);
        }

        public static void ExWrite(this MemoryStream stream, in short value)
        {
            stream.WriteByte((byte)value);
            stream.WriteByte((byte)(value >> 8));
        }

        public static void ExWrite(this MemoryStream stream, in ushort value)
        {
            stream.WriteByte((byte)value);
            stream.WriteByte((byte)(value >> 8));
        }

        public static void ExWrite(this MemoryStream stream, in int value)
        {
            stream.WriteByte((byte)value);
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)(value >> 16));
            stream.WriteByte((byte)(value >> 24));
        }

        public static void ExWrite(this MemoryStream stream, in uint value)
        {
            stream.WriteByte((byte)value);
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)(value >> 16));
            stream.WriteByte((byte)(value >> 24));
        }

        public static void ExWrite(this MemoryStream stream, in long value)
        {
            stream.WriteByte((byte)value);
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)(value >> 16));
            stream.WriteByte((byte)(value >> 24));
            stream.WriteByte((byte)(value >> 32));
            stream.WriteByte((byte)(value >> 40));
            stream.WriteByte((byte)(value >> 48));
            stream.WriteByte((byte)(value >> 56));
        }

        public static void ExWrite(this MemoryStream stream, in ulong value)
        {
            stream.WriteByte((byte)value);
            stream.WriteByte((byte)(value >> 8));
            stream.WriteByte((byte)(value >> 16));
            stream.WriteByte((byte)(value >> 24));
            stream.WriteByte((byte)(value >> 32));
            stream.WriteByte((byte)(value >> 40));
            stream.WriteByte((byte)(value >> 48));
            stream.WriteByte((byte)(value >> 56));
        }

        public static void ExWrite(this MemoryStream stream, in float value)
        {
            var src = BitConverter.GetBytes(value);

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(src);

            stream.Write(src, 0, src.Length);
        }

        public static void ExWrite(this MemoryStream stream, in double value)
        {
            var src = BitConverter.GetBytes(value);

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(src);

            stream.Write(src, 0, src.Length);
        }

        public static void ExWrite(this MemoryStream stream, in decimal value)
        {
            stream.ExWrite(decimal.GetBits(value));
        }

        public static void ExWrite(this MemoryStream stream, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            var bytes = Encoding.Default.GetBytes(value);

            stream.ExWrite(bytes);
        }

        public static void ExWrite(this MemoryStream stream, Guid guid)
        {
            var bytes = guid.ToByteArray();
            stream.ExWrite(bytes);
        }

        public static void ExWrite(this MemoryStream stream, IAutoSerialize value)
        {
            value?.Serialize(stream);
        }

        public static void ExWrite(this MemoryStream stream, string[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, bool[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, byte[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, sbyte[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, short[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, ushort[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, int[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, uint[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, long[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, ulong[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, float[] value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<string> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<bool> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<byte> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<sbyte> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<short> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<ushort> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<int> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<uint> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<long> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<ulong> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, List<float> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }

        public static void ExWrite(this MemoryStream stream, IReadOnlyCollection<IAutoSerialize> value)
        {
            if (value == null)
            {
                return;
            }

            foreach (var s in value)
            {
                stream.ExWrite(s);
            }
        }
    }
}