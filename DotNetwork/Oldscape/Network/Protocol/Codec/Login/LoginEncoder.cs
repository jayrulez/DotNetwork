// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Login
{

    /// <summary>
    /// The login encoder.
    /// </summary>
    sealed class LoginEncoder : MessageToByteEncoder<LoginResponse>
    {

        /// <summary>
        /// Encodes the login.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <param name="output"></param>
        protected override void Encode(IChannelHandlerContext context, LoginResponse message, IByteBuffer output)
        {
            var response = message.GetResponse();

            output.WriteByte((int)response);
            if (response == ConnectionMessage.SUCCESSFUL_LOGIN)
            {
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(2);// rights
                output.WriteByte(0);
                output.WriteShort(1);// index
                output.WriteByte(1);
            }
        }
    }
}
