// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Game.World.Region;
using DotNetwork.Oldscape.Network.Listener.Impl;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Player
{

    /// <summary>
    /// The player.
    /// </summary>
    sealed class Player : Actor
    {

        /// <summary>
        /// The session channel.
        /// </summary>
        private readonly IChannel channel;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="channel"></param>
        public Player(IChannel channel)
        {
            this.channel = channel;
        }

        /// <summary>
        /// Initiates and starts the player.
        /// </summary>
        public void Start()
        {
            SendPacket(new StaticRegionContext(Position));
            SendPacket(new RootInterfaceContext(548));
        }

        /// <summary>
        /// Sends a packet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        public void SendPacket<T>(T context) where T : PacketContext
        {
            if (channel.Registered)
                GamePacketListener.SendGamePacket(this, context);
        }

        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <returns></returns>
        public IChannel GetChannel()
        {
            return channel;
        }

    }
}
