// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using System.Collections.Generic;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Util.Buf;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Login
{

    /// <summary>
    /// The login decoder.
    /// </summary>
    sealed class LoginDecoder : ByteToMessageDecoder
    {

        /// <summary>
        /// Decodes the login.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (!input.IsReadable())
                return;

            LoginType type = Login.GetLoginType(input.ReadByte());
            if (type == LoginType.NONE)
                return;

            int size = input.ReadUnsignedShort();
            if (size != input.ReadableBytes)
                return;

            int version = input.ReadInt();
            int id = input.ReadByte();//RSA is disabled.
            if (id != 1)
                return;
            input.ReadByte();
            int[] clientKeys = new int[4];
            for (int index = 0; index < clientKeys.Length; index++)
            {
                clientKeys[index] = input.ReadInt();
            }
            input.SkipBytes(8);
            String password = IByteBufferExtensions.ReadString(input);
            Console.WriteLine(password);
            IByteBuffer buffer = IByteBufferExtensions.DecipherWithXTEA(input, clientKeys);
            String username = IByteBufferExtensions.ReadString(buffer);
            Console.WriteLine(username);
        }
    }
}
