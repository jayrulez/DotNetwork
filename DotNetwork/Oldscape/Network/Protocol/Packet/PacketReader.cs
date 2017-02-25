// Copyright(c) 2010-2011 Graham Edgecombe
// Copyright(c) 2011-2016 Major<major.emrs@gmail.com> and other apollo contributors
//
// Permission to use, copy, modify, and/or distribute this software for any
// purpose with or without fee is hereby granted, provided that the above
// copyright notice and this permission notice appear in all copies.
//
//
// THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
// WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
// ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
// WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
// ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
// OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

using DotNetty.Buffers;
using DotNetwork.Oldscape.Util.Buf;
using System;

namespace DotNetwork.Oldscape.Network.Protocol.Packet
{

    /// <summary>
    /// A class for reading packets.
    /// </summary>
    sealed class PacketReader
    {

        /// <summary>
        /// The buffer.
        /// </summary>
        private readonly IByteBuffer buffer;

        /// <summary>
        /// The current mode.
        /// </summary>
        private AccessMode mode = AccessMode.BYTE_ACCESS;

        /// <summary>
        /// The current bit index.
        /// </summary>
        private int bitIndex;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="buffer"></param>
        public PacketReader(IByteBuffer buffer)
        {
            this.buffer = buffer;
        }

        /// <summary>
        /// Checks that this builder is in the bit access mode.
        /// </summary>
        private void CheckBitAccess()
        {
            if (mode != AccessMode.BIT_ACCESS)
                throw new Exception("For bit-based calls to work, the mode must be bit access.");
        }

        /// <summary>
        /// Checks that this builder is in the byte access mode.
        /// </summary>
        private void CheckByteAccess()
        {
            if (mode != AccessMode.BYTE_ACCESS)
                throw new Exception("For bit-based calls to work, the mode must be byte access.");
        }

        /// <summary>
        /// Reads a standard data type from the buffer with the specified order and transformation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        /// <param name="transformation"></param>
        /// <returns></returns>
        private ulong Get(DataType type, DataOrder order, DataTransformation transformation)
        {
            CheckByteAccess();
            ulong longValue = 0;
            int length = (int)type;
            if (order == DataOrder.BIG)
            {
                for (int index = length - 1; index >= 0; index--)
                {
                    if (index == 0 && transformation != DataTransformation.NONE)
                    {
                        if (transformation == DataTransformation.ADD)
                            longValue |= (uint)buffer.ReadByte() - 128 & 0xFF;
                        else if (transformation == DataTransformation.NEGATE)
                            longValue |= (uint)-buffer.ReadByte() & 0xFF;
                        else if (transformation == DataTransformation.SUBTRACT)
                            longValue |= (uint)128 - buffer.ReadByte() & 0xFF;
                        else
                            throw new Exception("unknown transformation");
                    }
                    else
                        longValue |= (uint)(buffer.ReadByte() & 0xFF) << index * 8;
                }
            }
            else if (order == DataOrder.LITTLE)
            {
                for (int index = 0; index < length; index++)
                {
                    if (index == 0 && transformation != DataTransformation.NONE)
                    {
                        if (transformation == DataTransformation.ADD)
                            longValue |= (uint)buffer.ReadByte() - 128 & 0xFF;
                        else if (transformation == DataTransformation.NEGATE)
                            longValue |= (uint)-buffer.ReadByte() & 0xFF;
                        else if (transformation == DataTransformation.SUBTRACT)
                            longValue |= (uint)128 - buffer.ReadByte() & 0xFF;
                        else
                            throw new Exception("unknown transformation");
                    }
                    else
                        longValue |= (uint)(buffer.ReadByte() & 0xFF) << index * 8;
                }
            }
            else if (order == DataOrder.MIDDLE)
            {
                if (transformation != DataTransformation.NONE)
                    throw new Exception("middle endian cannot be transformed");

                if (type != DataType.INT)
                    throw new Exception("middle endian can only be used with an integer");

                longValue |= (uint)(buffer.ReadByte() & 0xFF) << 8;
                longValue |= (uint)buffer.ReadByte() & 0xFF;
                longValue |= (uint)(buffer.ReadByte() & 0xFF) << 24;
                longValue |= (uint)(buffer.ReadByte() & 0xFF) << 16;
            }
            else if (order == DataOrder.INVERSED_MIDDLE)
            {
                if (transformation != DataTransformation.NONE)
                    throw new Exception("inversed middle endian cannot be transformed");

                if (type != DataType.INT)
                    throw new Exception("inversed middle endian can only be used with an integer");

                longValue |= (uint)(buffer.ReadByte() & 0xFF) << 16;
                longValue |= (uint)(buffer.ReadByte() & 0xFF) << 24;
                longValue |= (uint)buffer.ReadByte() & 0xFF;
                longValue |= (uint)(buffer.ReadByte() & 0xFF) << 8;
            }
            else
                throw new Exception("unknown order");

            return longValue;
        }

        /// <summary>
        /// Gets a bit from the buffer.
        /// </summary>
        /// <returns></returns>
        public int GetBit()
        {
            return GetBits(1);
        }

        /// <summary>
        /// Gets the num bits from the buffer.
        /// </summary>
        /// <param name="numBits"></param>
        /// <returns></returns>
        public int GetBits(int numBits)
        {
            if (numBits < 0 || numBits > 32)
                throw new Exception("Number of bits must be between 1 and 32 inclusive");

            CheckBitAccess();

            int bytePos = bitIndex >> 3;
            int bitOffset = 8 - (bitIndex & 7);
            int value = 0;
            bitIndex += numBits;

            for (; numBits > bitOffset; bitOffset = 8)
            {
                value += (buffer.GetByte(bytePos++) & DataConstants.BIT_MASK[bitOffset]) << numBits - bitOffset;
                numBits -= bitOffset;
            }
            if (numBits == bitOffset)
                value += buffer.GetByte(bytePos) & DataConstants.BIT_MASK[bitOffset];
            else
                value += buffer.GetByte(bytePos) >> bitOffset - numBits & DataConstants.BIT_MASK[numBits];

            return value;
        }

        /// <summary>
        /// Gets bytes.
        /// </summary>
        /// <param name="bytes"></param>
        public void GetBytes(byte[] bytes)
        {
            CheckByteAccess();
            for (int index = 0; index < bytes.Length; index++)
                bytes[index] = buffer.ReadByte();
        }

        /// <summary>
        /// Gets bytes with the specified transformation.
        /// </summary>
        /// <param name="transformation"></param>
        /// <param name="bytes"></param>
        public void GetBytes(DataTransformation transformation, byte[] bytes)
        {
            if (transformation == DataTransformation.NONE)
                GetBytesReverse(bytes);
            else
            {
                for (int index = 0; index < bytes.Length; index++)
                    bytes[index] = (byte)GetSigned(DataType.BYTE, transformation);
            }
        }

        /// <summary>
        /// Gets bytes in reverse.
        /// </summary>
        /// <param name="bytes"></param>
        public void GetBytesReverse(byte[] bytes)
        {
            CheckByteAccess();
            for (int index = bytes.Length - 1; index >= 0; index--)
                bytes[index] = buffer.ReadByte();
        }

        /// <summary>
        /// Gets bytes in reverse with the specified transformation.
        /// </summary>
        /// <param name="transformation"></param>
        /// <param name="bytes"></param>
        public void GetBytesReverse(DataTransformation transformation, byte[] bytes)
        {
            if (transformation == DataTransformation.NONE)
                GetBytesReverse(bytes);
            else
            {
                for (int i = bytes.Length - 1; i >= 0; i--)
                    bytes[i] = (byte)GetSigned(DataType.BYTE, transformation);
            }
        }

        /// <summary>
        /// Gets the length of this reader.
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            CheckByteAccess();
            return buffer.WritableBytes;
        }

        /// <summary>
        /// Gets a signed data type from the buffer.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ulong GetSigned(DataType type)
        {
            return GetSigned(type, DataOrder.BIG, DataTransformation.NONE);
        }

        /// <summary>
        /// Gets a signed data type from the buffer with the specified order.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public ulong GetSigned(DataType type, DataOrder order)
        {
            return GetSigned(type, order, DataTransformation.NONE);
        }

        /// <summary>
        /// Gets a signed data type from the buffer with the specified order and transformation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        /// <param name="transformation"></param>
        /// <returns></returns>
        public ulong GetSigned(DataType type, DataOrder order, DataTransformation transformation)
        {
            ulong longValue = Get(type, order, transformation);
            if (type != DataType.LONG)
            {
                uint max = (uint)(int)(Math.Pow(2, (int)type * 8 - 1) - 1);
                if (longValue > max)
                    longValue -= (max + 1) * 2;
            }
            return longValue;
        }

        /// <summary>
        /// Gets a signed data type from the buffer with the specified transformation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="transformation"></param>
        /// <returns></returns>
        public ulong GetSigned(DataType type, DataTransformation transformation)
        {
            return GetSigned(type, DataOrder.BIG, transformation);
        }

        /// <summary>
        /// Gets a signed smart from the buffer.
        /// </summary>
        /// <returns></returns>
        public int GetSignedSmart()
        {
            CheckByteAccess();
            int peek = buffer.GetByte(buffer.ReaderIndex);
            if (peek < 128)
                return buffer.ReadByte() - 64;
            else
                return buffer.ReadShort() - 49152;
        }

        /// <summary>
        /// Gets a string from the buffer.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            CheckByteAccess();
            return IByteBufferExtensions.ReadString(buffer);
        }

        /// <summary>
        /// Gets an unsigned data type from the buffer.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ulong GetUnsigned(DataType type)
        {
            return GetUnsigned(type, DataOrder.BIG, DataTransformation.NONE);
        }

        /// <summary>
        /// Gets an unsigned data type from the buffer with the specified order.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public ulong GetUnsigned(DataType type, DataOrder order)
        {
            return GetUnsigned(type, order, DataTransformation.NONE);
        }

        /// <summary>
        /// Gets an unsigned data type from the buffer with the specified order and transformation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        /// <param name="transformation"></param>
        /// <returns></returns>
        public ulong GetUnsigned(DataType type, DataOrder order, DataTransformation transformation)
        {
            ulong longValue = Get(type, order, transformation);
            if (type == DataType.LONG)
            {
                throw new Exception("due to java restrictions, longs must be read as signed types");
            }
            return longValue & 0xFFFFFFFFFFFFFFFFL;
        }

        /// <summary>
        /// Gets an unsigned data type from the buffer with the specified transformation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="transformation"></param>
        /// <returns></returns>
        public ulong GetUnsigned(DataType type, DataTransformation transformation)
        {
            return GetUnsigned(type, DataOrder.BIG, transformation);
        }

        /// <summary>
        /// Gets an unsigned smart from the buffer.
        /// </summary>
        /// <returns></returns>
        public int getUnsignedSmart()
        {
            CheckByteAccess();
            int peek = buffer.GetByte(buffer.ReaderIndex);
            if (peek < 128)
                return buffer.ReadByte();
            else
                return buffer.ReadShort() - 32768;
        }

        /// <summary>
        /// Switches this builder's mode to the bit access mode.
        /// </summary>
        public void SwitchToBitAccess()
        {
            if (mode == AccessMode.BIT_ACCESS)
                return;

            mode = AccessMode.BIT_ACCESS;
            bitIndex = buffer.WriterIndex * 8;
        }

        /// <summary>
        /// Switches this builder's mode to the byte access mode.
        /// </summary>
        public void SwitchToByteAccess()
        {
            if (mode == AccessMode.BYTE_ACCESS)
                return;

            mode = AccessMode.BYTE_ACCESS;
            buffer.SetWriterIndex((bitIndex + 7) / 8);
        }

        /// <summary>
        /// Gets the buffer.
        /// </summary>
        /// <returns></returns>
        public IByteBuffer GetBuffer()
        {
            return buffer;
        }

    }
}
