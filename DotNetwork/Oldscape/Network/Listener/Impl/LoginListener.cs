// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Network.Protocol.Codec.Login;
using DotNetwork.Oldscape.Network.Protocol;
using DotNetwork.Oldscape.Network.Protocol.CacheFS;
using DotNetty.Buffers;
using DotNetwork.Oldscape.Network.Protocol.Codec.Game;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

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
        public void MessageRead(IChannelHandlerContext context, object message)
        {
            if (message.GetType() == typeof(LoginRequest))
            {
                var request = (LoginRequest)message;
                var response = CheckLogin(request);
                var channel = context.Channel;
                var pipeline = channel.Pipeline;


                if (response != ConnectionMessage.SUCCESSFUL_LOGIN)
                {
                    channel.WriteAndFlushAsync(Unpooled.Buffer(1).WriteByte((int)response));
                    return;
                }

                var player = new Player(channel);
                channel.WriteAndFlushAsync(new LoginResponse(response));

                channel.GetAttribute(NetworkHandler.CURR_LISTENER).Set(new GamePacketListener());
                pipeline.AddAfter("login.decoder", "game.encoder", new GamePacketEncoder(request.GetIsaacRandGroup().GetEncoderRand()));
                pipeline.Replace("login.decoder", "game.decoder", new GamePacketDecoder(player, request.GetIsaacRandGroup().GetDecoderRand()));

                player.Start();
            }
        }

        /// <summary>
        /// Checks the login status before connecting the player to the game world.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private ConnectionMessage CheckLogin(LoginRequest request)
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

            return ConnectionMessage.SUCCESSFUL_LOGIN;
        }
    }
}
