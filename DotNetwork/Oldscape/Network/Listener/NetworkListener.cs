// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;

namespace DotNetwork.Oldscape.Network.Listener
{

    /// <summary>
    /// A interface used for different network listeners.
    /// </summary>
    interface NetworkListener
    {

        /// <summary>
        /// Reads the inbound data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        void MessageRead(IChannelHandlerContext context, object message);

    }
}
