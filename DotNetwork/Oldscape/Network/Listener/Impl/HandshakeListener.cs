// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Network.Protocol.Codec.Handshake;
using DotNetwork.Oldscape.Network.Protocol;

namespace DotNetwork.Oldscape.Network.Listener.Impl
{

    /// <summary>
    /// The handshake listener.
    /// </summary>
    sealed class HandshakeListener : NetworkListener
    {

        /// <summary>
        /// Reads the inbound data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public override void MessageRead(IChannelHandlerContext context, object message)
        {
            if (message.GetType() == typeof(HandshakeRequest))
            {
                var request = (HandshakeRequest)message;
                var response = ConnectionMessage.OUT_OF_DATE;

                switch (request.GetHandshakeType())
                {
                    case HandshakeType.UPDATE_CONNECTION:
                        if (request.GetVersion() == Server.VERSION)
                            response = ConnectionMessage.UP_TO_DATE;
                        break;
                    case HandshakeType.LOGIN_CONNECTION:
                        //TODO Login
                        break;
                }

                context.Channel.WriteAndFlushAsync(new HandshakeResponse(request.GetHandshakeType(), response));
            }
        }
    }
}
