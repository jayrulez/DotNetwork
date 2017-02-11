// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Codecs;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Network.Protocol.Codec.Update;
using DotNetwork.Oldscape.Network.Listener.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Handshake
{

    /// <summary>
    /// The handshake encoder.
    /// </summary>
    sealed class HandshakeEncoder : MessageToByteEncoder<HandshakeResponse>
    {

        /// <summary>
        /// Encodes the handshake.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <param name="output"></param>
        protected override void Encode(IChannelHandlerContext context, HandshakeResponse message, IByteBuffer output)
        {
            ConnectionMessage response = message.GetConnectionMessage();

            output.WriteByte((int)response);
            if (response == ConnectionMessage.UP_TO_DATE)//TODO Fix for login
            {
                switch (message.GetHandshakeType())
                {
                    case HandshakeType.UPDATE_CONNECTION:
                        context.Channel.GetAttribute(NetworkHandler.CURR_LISTENER).Set(new UpdateListener());
                        context.Channel.Pipeline.AddAfter("decoder", "update.encoder", new UpdateEncoder());
                        context.Channel.Pipeline.Replace("decoder", "update.decoder", new UpdateDecoder());
                        break;
                    case HandshakeType.LOGIN_CONNECTION:
                        break;
                }
            }
        }
    }
}
