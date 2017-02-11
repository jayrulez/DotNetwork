// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Network.Protocol.Codec.Update;
using DotNetty.Buffers;
using DotNetwork.Oldscape.Network.Protocol.CacheStore;

namespace DotNetwork.Oldscape.Network.Listener.Impl
{

    /// <summary>
    /// The update listener.
    /// </summary>
    sealed class UpdateListener : NetworkListener
    {
        /// <summary>
        /// Reads the inbound data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public override void MessageRead(IChannelHandlerContext context, object message)
        {
            if (message.GetType() == typeof(UpdateRequest))
            {
                var request = (UpdateRequest)message;
                int index = request.GetIndex();
                int archive = request.GetArchive();
                IByteBuffer container = null;

                //Get the cache data based on the requested index and archive.
                if (index == 0xff && archive == 0xff)
                {
                    container = Unpooled.CopiedBuffer(CacheManager.GetChecksumBuffer());
                }
                else
                {
                    container = Unpooled.CopiedBuffer(CacheManager.GetCache().GetStore().Read(index, archive).array());
                    if (index != 0xff)
                        container = container.Slice(0, container.ReadableBytes - 2);
                }

                if (container != null)
                    context.Channel.WriteAndFlushAsync(new UpdateResponse(index, archive, request.IsPriority(), container));
            }
        }
    }
}
