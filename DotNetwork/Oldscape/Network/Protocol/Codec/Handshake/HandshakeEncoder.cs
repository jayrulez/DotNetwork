// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Codecs;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Network.Protocol.Codec.Update;
using DotNetwork.Oldscape.Network.Listener.Impl;
using DotNetwork.Oldscape.Network.Protocol.Codec.Login;

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
            var response = message.GetConnectionMessage();
            var pipeline = context.Channel.Pipeline;

            output.WriteByte((int)response);
            if (response == ConnectionMessage.SUCCESSFUL)
            {
                switch (message.GetHandshakeType())
                {
                    case HandshakeType.UPDATE_CONNECTION:
                        context.Channel.GetAttribute(NetworkHandler.CURR_LISTENER).Set(new UpdateListener());
                        pipeline.AddAfter("decoder", "update.encoder", new UpdateEncoder());
                        pipeline.Replace("decoder", "update.decoder", new UpdateDecoder());
                        break;
                    case HandshakeType.LOGIN_CONNECTION:
                        context.Channel.GetAttribute(NetworkHandler.CURR_LISTENER).Set(new LoginListener());
                        pipeline.AddAfter("decoder", "login.encoder", new LoginEncoder());
                        pipeline.Replace("decoder", "login.decoder", new LoginDecoder());
                        break;
                }
            }
            pipeline.Remove(this);
        }
    }
}
