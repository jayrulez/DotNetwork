// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using System.Collections.Generic;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Game
{

    /// <summary>
    /// The packet decoder.
    /// </summary>
    sealed class GamePacketDecoder : ByteToMessageDecoder
    {

        /// <summary>
        /// Decodes a game packet from the client.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (!input.IsReadable())
                return;

            Console.WriteLine("Decode packet.");
        }
    }
}
