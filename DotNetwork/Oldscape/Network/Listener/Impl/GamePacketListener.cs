// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context;
using DotNetwork.Oldscape.Network.Protocol.Packet;
using DotNetwork.Oldscape.Network.Protocol.Packet.Encoder;
using DotNetwork.Oldscape.Network.Protocol.Codec.Game;
using System;

namespace DotNetwork.Oldscape.Network.Listener.Impl
{

    /// <summary>
    /// The game packet listener.
    /// </summary>
    sealed class GamePacketListener : NetworkListener
    {

        /// <summary>
        /// Reads the inbound data.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        public void MessageRead(IChannelHandlerContext context, object message)
        {
            if (message.GetType() == typeof(GamePacketRequest))
            {
                var request = (GamePacketRequest)message;
                int id = request.GetId();
                var packet = PacketRepository.GetPacketDecoder(id);

                //dont use preconditions because it doesnt need to throw some exception.
                if (packet == null)
                {
                    Console.WriteLine($"Incoming packet not implemented: {id}.");
                    return;
                }

                packet.Decode(request.GetPlayer(), id, new PacketReader(request.GetPayload()));
            }
        }

        /// <summary>
        /// Sends a game packet to the client.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="channel"></param>
        /// <param name="context"></param>
        public static void SendGamePacket<T>(IChannel channel, T context) where T : PacketContext
        {
            var packet = PacketRepository.GetPacketEncoder(context) as PacketEncoder<T>;
            Preconditions.Check.NotNull(packet, $"Packet not found for context {context.ToString()}").Encode(context);

            channel.WriteAndFlushAsync(new GamePacketResponse(packet.GetId(), packet.GetPacketType(), packet.GetBuilder()));
        }

    }
}
