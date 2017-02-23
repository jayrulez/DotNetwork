// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Game.World.Region;
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
        /// The viewport.
        /// </summary>
        private readonly Viewport viewport;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="channel"></param>
        public Player(IChannel channel)
        {
            this.channel = channel;
            viewport = new Viewport(this);
        }

        /// <summary>
        /// Initiates and starts the player.
        /// </summary>
        public void Start()
        {
            SendPacket(new RootInterfaceContext(548));
        }

        public void SendPacket(PacketContext context)
        {

        }

        /// <summary>
        /// Gets the channel.
        /// </summary>
        /// <returns></returns>
        public IChannel GetChannel()
        {
            return channel;
        }

        /// <summary>
        /// Gets the viewport.
        /// </summary>
        /// <returns></returns>
        public Viewport GetViewport()
        {
            return viewport;
        }

    }
}
