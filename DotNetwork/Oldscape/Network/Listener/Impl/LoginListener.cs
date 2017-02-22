// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Network.Protocol.Codec.Login;
using DotNetwork.Oldscape.Network.Protocol;
using DotNetwork.Oldscape.Network.Protocol.CacheFS;

namespace DotNetwork.Oldscape.Network.Listener.Impl
{

    /// <summary>
    /// The login listener.
    /// </summary>
    sealed class LoginListener : NetworkListener
    {

        /// <summary>
        /// Reads the inbound data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public override void MessageRead(IChannelHandlerContext context, object message)
        {
            if (message.GetType() == typeof(LoginRequest))
            {
                var request = (LoginRequest)message;
                var response = checkLogin(request);
                Console.WriteLine(response);
            }
        }

        private ConnectionMessage checkLogin(LoginRequest request)
        {

            if (request.GetVersion() != Server.VERSION)
                return ConnectionMessage.OUT_OF_DATE;

            if (!request.GetToken().Equals("ElZAIrq5NpKN6D3mDdihco3oPeYN2KFy2DCquj7JMmECPmLrDP3Bnw"))
                return ConnectionMessage.OUT_OF_DATE;

            for (int index = 0; index < request.GetCrc().Length; index++)
            {
                if (CacheManager.GetChecksumTable().GetEntry(index).GetCrc() != request.GetCrc()[index])
                {
                    //Console.WriteLine(CacheManager.GetChecksumTable().GetEntry(index).GetCrc() + ", " + request.GetCrc()[index]);
                }
            }

            return ConnectionMessage.SUCCESSFUL;
        }
    }
}
