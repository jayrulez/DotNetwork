// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Codecs;
using System.Collections.Generic;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Handshake
{

    /// <summary>
    /// The handshake decoder.
    /// </summary>
    sealed class HandshakeDecoder : ByteToMessageDecoder
    {

        /// <summary>
        /// Decodes the handshake.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (!input.IsReadable())
                return;

            HandshakeType type = Handshake.GetHandshakeType(input.ReadByte());
            if (type == HandshakeType.NONE)
                return;

            switch (type)
            {
                case HandshakeType.UPDATE_CONNECTION:
                    int version = input.ReadInt();
                    output.Add(new HandshakeRequest(type, version));
                    break;
                case HandshakeType.LOGIN_CONNECTION:
                    context.Channel.WriteAndFlushAsync(new HandshakeResponse(type, ConnectionMessage.SUCCESSFUL));
                    break;
            }
        }
    }
}
