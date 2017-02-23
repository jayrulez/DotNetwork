// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context;
using DotNetwork.Oldscape.Network.Protocol.Packet;
using DotNetwork.Oldscape.Network.Protocol.Packet.Encoder;
using DotNetwork.Oldscape.Network.Protocol.Codec.Game;

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

        }

        /// <summary>
        /// Sends a game packet to the client.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="player"></param>
        /// <param name="context"></param>
        public static void SendGamePacket<T>(Player player, T context) where T : PacketContext
        {
            PacketEncoder<T> packet = PacketRepository.GetPacketEncoder(context) as PacketEncoder<T>;
            Preconditions.Check.NotNull(packet, $"Packet not found for context {context.ToString()}").Encode(context);

            player.GetChannel().WriteAndFlushAsync(new GamePacketResponse(packet.GetId(), packet.GetPacketType(), packet.GetBuilder()));
        }

    }
}
