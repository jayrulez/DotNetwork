// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Codecs;
using System.Collections.Generic;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using System;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Update
{
    /// <summary>
    /// The update decoder.
    /// </summary>
    sealed class UpdateDecoder : ByteToMessageDecoder
    {
        /// <summary>
        /// Decodes a file update.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (!input.IsReadable() || input.ReadableBytes < 4)
                return;

            UpdateType type = Update.GetUpdateType(input.ReadByte() & 0xff);
            if (type == UpdateType.NONE)
            {
                input.SkipBytes(3);
                return;
            }

            switch (type)
            {
                case UpdateType.LOW_PRIORITY_UPDATE:
                case UpdateType.HIGH_PRIORITY_UPDATE:
                    int index = input.ReadByte() & 0xff;
                    int archive = input.ReadUnsignedShort();

                    output.Add(new UpdateRequest(index, archive, type == UpdateType.HIGH_PRIORITY_UPDATE));
                    break;
                case UpdateType.ENCRYPTION_UPDATE:
                    input.SkipBytes(3);
                    break;
            }
        }
    }
}
