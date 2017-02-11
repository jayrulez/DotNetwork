// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;

namespace DotNetwork.Oldscape.Network.Listener
{

    /// <summary>
    /// An abstract class used for different network listeners.
    /// </summary>
    abstract class NetworkListener
    {

        /// <summary>
        /// Reads the inbound data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public abstract void MessageRead(IChannelHandlerContext context, object message);

        /// <summary>
        /// Writes a message async with the channel.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public virtual void WriteAndFlushAsync(IChannelHandlerContext context, object message)
        {
            context.Channel.WriteAndFlushAsync(Preconditions.Check.NotNull(message, "Channel message is null."));
        }

        /// <summary>
        /// Writes a message async with the channel.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public virtual void WriteAsync(IChannelHandlerContext context, object message)
        {
            context.Channel.WriteAsync(Preconditions.Check.NotNull(message, "Channel message is null."));
        }
    }
}
