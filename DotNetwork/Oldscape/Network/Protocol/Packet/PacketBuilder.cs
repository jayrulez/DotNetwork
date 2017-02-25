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
using System.Text;

namespace DotNetwork.Oldscape.Network.Protocol.Packet
{

    /// <summary>
    /// Assists in creating a packet.
    /// </summary>
    sealed class PacketBuilder
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
        public PacketBuilder() : this(Unpooled.Buffer()) { }

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="buffer"></param>
        public PacketBuilder(IByteBuffer buffer)
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
        /// Gets the current length of the builder's buffer.
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            CheckByteAccess();
            return buffer.WriterIndex;
        }

        /// <summary>
        /// Puts a standard data type with the specified value, byte order and transformation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        /// <param name="transformation"></param>
        /// <param name="value"></param>
        public void Put(DataType type, DataOrder order, DataTransformation transformation, long value)
        {
            CheckByteAccess();
            int length = (int)type;
            switch (order)
            {
                case DataOrder.BIG:
                    for (int index = length - 1; index >= 0; index--)
                    {
                        if (index == 0 && transformation != DataTransformation.NONE)
                        {
                            if (transformation == DataTransformation.ADD)
                                buffer.WriteByte((byte)(value + 128));
                            else if (transformation == DataTransformation.NEGATE)
                                buffer.WriteByte((byte)-value);
                            else if (transformation == DataTransformation.SUBTRACT)
                                buffer.WriteByte((byte)(128 - value));
                            else
                                throw new Exception("Unknown transformation.");
                        }
                        else
                            buffer.WriteByte((byte)(value >> index * 8));
                    }
                    break;
                case DataOrder.INVERSED_MIDDLE:
                    if (transformation != DataTransformation.NONE)
                        throw new Exception("Inversed middle endian cannot be transformed.");

                    if (type != DataType.INT)
                        throw new Exception("Inversed middle endian can only be used with an integer.");

                    buffer.WriteByte((byte)(value >> 16));
                    buffer.WriteByte((byte)(value >> 24));
                    buffer.WriteByte((byte)value);
                    buffer.WriteByte((byte)(value >> 8));
                    break;
                case DataOrder.LITTLE:
                    for (int index = 0; index < length; index++)
                    {
                        if (index == 0 && transformation != DataTransformation.NONE)
                        {
                            if (transformation == DataTransformation.ADD)
                                buffer.WriteByte((byte)(value + 128));
                            else if (transformation == DataTransformation.NEGATE)
                                buffer.WriteByte((byte)-value);
                            else if (transformation == DataTransformation.SUBTRACT)
                                buffer.WriteByte((byte)(128 - value));
                            else
                                throw new Exception("Unknown transformation.");
                        }
                        else
                            buffer.WriteByte((byte)(value >> index * 8));
                    }
                    break;
                case DataOrder.MIDDLE:
                    if (transformation != DataTransformation.NONE)
                        throw new Exception("Middle endian cannot be transformed.");

                    if (type != DataType.INT)
                        throw new Exception("Middle endian can only be used with an integer.");

                    buffer.WriteByte((byte)(value >> 8));
                    buffer.WriteByte((byte)value);
                    buffer.WriteByte((byte)(value >> 24));
                    buffer.WriteByte((byte)(value >> 16));
                    break;
            }
        }

        /// <summary>
        /// Puts a standard data type with the specified value and byte order.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        /// <param name="value"></param>
        public void Put(DataType type, DataOrder order, long value)
        {
            Put(type, order, DataTransformation.NONE, value);
        }

        /// <summary>
        /// Puts a standard data type with the specified value and transformation.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="transformation"></param>
        /// <param name="value"></param>
        public void Put(DataType type, DataTransformation transformation, long value)
        {
            Put(type, DataOrder.BIG, transformation, value);
        }

        /// <summary>
        /// Puts a standard data type with the specified value.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void Put(DataType type, long value)
        {
            Put(type, DataOrder.BIG, DataTransformation.NONE, value);
        }

        /// <summary>
        /// Puts a single bit into the buffer. If {@code flag} is {@code true}, the value of the bit is {@code 1}. If {@code flag} is {@code false}, the value of the bit is {@code 0}.
        /// </summary>
        /// <param name="flag"></param>
        public void PutBit(bool flag)
        {
            PutBit(flag ? 1 : 0);
        }

        /// <summary>
        /// Puts a single bit into the buffer with the value {@code value}.
        /// </summary>
        /// <param name="value"></param>
        public void PutBit(int value)
        {
            PutBits(1, value);
        }

        /// <summary>
        /// Puts {@code numBits} into the buffer with the value {@code value}.
        /// </summary>
        /// <param name="numBits"></param>
        /// <param name="value"></param>
        public void PutBits(int numBits, int value)
        {
            CheckBitAccess();

            int bytePos = bitIndex >> 3;
            int bitOffset = 8 - (bitIndex & 7);
            bitIndex += numBits;

            int requiredSpace = bytePos - buffer.WriterIndex + 1;
            requiredSpace += (numBits + 7) / 8;
            buffer.EnsureWritable(requiredSpace);

            for (; numBits > bitOffset; bitOffset = 8)
            {
                int tmp = buffer.GetByte(bytePos);
                tmp &= ~DataConstants.BIT_MASK[bitOffset];
                tmp |= value >> numBits - bitOffset & DataConstants.BIT_MASK[bitOffset];
                buffer.SetByte(bytePos++, tmp);
                numBits -= bitOffset;
            }
            if (numBits == bitOffset)
            {
                int tmp = buffer.GetByte(bytePos);
                tmp &= ~DataConstants.BIT_MASK[bitOffset];
                tmp |= value & DataConstants.BIT_MASK[bitOffset];
                buffer.SetByte(bytePos, tmp);
            }
            else
            {
                int tmp = buffer.GetByte(bytePos);
                tmp &= ~(DataConstants.BIT_MASK[numBits] << bitOffset - numBits);
                tmp |= (value & DataConstants.BIT_MASK[numBits]) << bitOffset - numBits;
                buffer.SetByte(bytePos, tmp);
            }
        }

        /// <summary>
        /// Puts the specified byte array into the buffer.
        /// </summary>
        /// <param name="bytes"></param>
        public void PutBytes(byte[] bytes)
        {
            buffer.WriteBytes(bytes);
        }

        /// <summary>
        /// Puts the bytes from the specified buffer into this packet's buffer.
        /// </summary>
        /// <param name="buffer"></param>
        public void PutBytes(IByteBuffer buffer)
        {
            byte[] bytes = new byte[buffer.ReadableBytes];
            buffer.MarkReaderIndex();
            try
            {
                buffer.ReadBytes(bytes);
            }
            finally
            {
                buffer.ResetReaderIndex();
            }
            PutBytes(bytes);
        }

        /// <summary>
        /// Puts the bytes into the buffer with the specified transformation.
        /// </summary>
        /// <param name="transformation"></param>
        /// <param name="bytes"></param>
        public void PutBytes(DataTransformation transformation, byte[] bytes)
        {
            if (transformation == DataTransformation.NONE)
                PutBytes(bytes);
            else
            {
                foreach (byte b in bytes)
                    Put(DataType.BYTE, transformation, b);
            }
        }

        /// <summary>
        /// Puts the specified byte array into the buffer in reverse.
        /// </summary>
        /// <param name="bytes"></param>
        public void PutBytesReverse(byte[] bytes)
        {
            CheckByteAccess();
            for (int index = bytes.Length - 1; index >= 0; index--)
                buffer.WriteByte(bytes[index]);
        }

        /// <summary>
        /// Puts the bytes from the specified buffer into this packet's buffer, in reverse.
        /// </summary>
        /// <param name="buffer"></param>
        public void PutBytesReverse(IByteBuffer buffer)
        {
            byte[] bytes = new byte[buffer.ReadableBytes];
            buffer.MarkReaderIndex();
            try
            {
                buffer.ReadBytes(bytes);
            }
            finally
            {
                buffer.ResetReaderIndex();
            }
            PutBytesReverse(bytes);
        }

        /// <summary>
        /// Puts the specified byte array into the buffer in reverse with the specified transformation.
        /// </summary>
        /// <param name="transformation"></param>
        /// <param name="bytes"></param>
        public void PutBytesReverse(DataTransformation transformation, byte[] bytes)
        {
            if (transformation == DataTransformation.NONE)
                PutBytesReverse(bytes);
            else
            {
                for (int index = bytes.Length - 1; index >= 0; index--)
                    Put(DataType.BYTE, transformation, bytes[index]);
            }
        }

        /// <summary>
        /// Puts a smart into the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void PutSmart(int value)
        {
            CheckByteAccess();
            if (value >= 128)
                buffer.WriteShort(value + 32768);
            else
                buffer.WriteByte(value);
        }

        /// <summary>
        /// Puts a large smart into the buffer.
        /// </summary>
        /// <param name="value"></param>
        public void PutLargeSmart(int value)
        {
            CheckByteAccess();
            if (value >= Int16.MaxValue)
            {
                buffer.WriteInt(value - Int32.MaxValue - 1);
            }
            else
            {
                buffer.WriteShort(value >= 0 ? value : 32767);
            }
        }

        /// <summary>
        /// Puts a string into the buffer.
        /// </summary>
        /// <param name="str"></param>
        public void PutString(string str)
        {
            CheckByteAccess();

            buffer.WriteBytes(Encoding.ASCII.GetBytes(str));
            buffer.WriteByte(IByteBufferExtensions.STRING_TERMINATOR);
        }

        /// <summary>
        /// Puts a jagex string into the buffer.
        /// </summary>
        /// <param name="str"></param>
        public void PutJagString(string str)
        {
            CheckByteAccess();

            IByteBufferExtensions.WriteJagString(buffer, str);
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
