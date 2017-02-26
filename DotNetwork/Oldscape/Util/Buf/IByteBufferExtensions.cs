// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Buffers;
using System;
using System.Text;

namespace DotNetwork.Oldscape.Util.Buf
{

    /// <summary>
    /// The byte buf utils for netty implementation.
    /// </summary>
    sealed class IByteBufferExtensions
    {

        /// <summary>
        /// The string terminator.
        /// </summary>
        public const int STRING_TERMINATOR = 0;

        /// <summary>
        /// Converts byte data from a byte buffer into a readable string.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string ReadString(IByteBuffer buffer)
        {
            var builder = new StringBuilder();
            byte a;
            while (buffer.IsReadable() && (a = buffer.ReadByte()) != STRING_TERMINATOR)
                builder.Append((char)a);
            return builder.ToString();
        }

        /// <summary>
        /// Deciphers a byte buffer with a unique key.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IByteBuffer DecipherWithXTEA(IByteBuffer buffer, int[] keys)
        {
            if (keys.Length != 4)
                return null;

            int length = buffer.ReadableBytes;
            byte[] bytes = new byte[length];
            buffer.ReadBytes(bytes);
            return DecryptXTEA(Unpooled.WrappedBuffer(bytes), 0, length, keys);
        }

        /// <summary>
        /// Decryptes data using XTEA.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        private static IByteBuffer DecryptXTEA(IByteBuffer buffer, int start, int end, int[] keys)
        {
            int length = (end - start) / 8;
            for (int index = 0; index < length; index++)
            {
                int v1 = buffer.GetInt(start + index * 8);
                int v0 = buffer.GetInt(start + index * 8 + 4);
                int ratio = unchecked((int)0x9e3779b9);
                int rounds = 32;
                int offset = ratio * rounds;
                while (rounds-- > 0)
                {
                    v0 -= (((int)((uint)v1 >> -1563092443) ^ v1 << 611091524) + v1 ^ offset + keys[(int)((uint)offset >> -1002502837) & 0x56c00003]);
                    offset -= ratio;
                    v1 -= (((int)((uint)v0 >> 1337206757) ^ v0 << 363118692) - -v0 ^ offset + keys[offset & 0x3]);
                }
                buffer.SetInt(start + index * 8, v1);
                buffer.SetInt(start + index * 8 + 4, v0);
            }
            return buffer;
        }

    }
}
