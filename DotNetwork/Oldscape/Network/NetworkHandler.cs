// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Network.Listener;
using DotNetwork.Oldscape.Network.Listener.Impl;

namespace DotNetwork.Oldscape.Network
{

    /// <summary>
    /// The network handler.
    /// </summary>
    sealed class NetworkHandler : ChannelHandlerAdapter
    {
        /// <summary>
        /// The current network listener.
        /// </summary>
        public static readonly AttributeKey<NetworkListener> CURR_LISTENER = AttributeKey<NetworkListener>.ValueOf("listener");

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="channel"></param>
        public NetworkHandler(IChannel channel)
        {
            channel.GetAttribute(CURR_LISTENER).Set(new HandshakeListener());
        }

        /// <summary>
        /// Handles the read channel messages.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            try
            {
                NetworkListener listener = Preconditions.Check.NotNull(context.Channel.GetAttribute(CURR_LISTENER).Get(), "Network attribute key is null.");
                if (listener != null && context.Channel.Registered)
                {
                    listener.MessageRead(context, message);
                }
            }
            finally
            {
                ReferenceCountUtil.Release(message);
            }
        }
    }
}