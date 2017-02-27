// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Codecs;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Update
{

    /// <summary>
    /// The update encoder.
    /// </summary>
    sealed class UpdateEncoder : MessageToByteEncoder<UpdateResponse>
    {

        /// <summary>
        /// Encodes a update file.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <param name="output"></param>
        protected override void Encode(IChannelHandlerContext context, UpdateResponse message, IByteBuffer output)
        {
            int index = message.GetIndex();
            int archive = message.GetArchive();
            var container = message.GetContainer();

            int compression = container.ReadByte() & 0xff;
            int length = container.ReadInt();

            output.WriteByte(index);
            output.WriteShort(archive);
            output.WriteByte(compression);
            output.WriteInt(length);

            int bytes = container.ReadableBytes;
            if (bytes > 504)
                bytes = 504;
            output.WriteBytes(container.ReadBytes(bytes));
            for (;;)
            {
                bytes = container.ReadableBytes;
                if (bytes == 0)
                    break;
                else if (bytes > 511)
                    bytes = 511;
                output.WriteByte(0xff);
                output.WriteBytes(container.ReadBytes(bytes));
            }
        }
    }
}
