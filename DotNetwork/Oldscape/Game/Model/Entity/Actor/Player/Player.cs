// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Manager;
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
        /// The interface manager.
        /// </summary>
        private readonly InterfaceManager interfaceManager;

        /// <summary>
        /// The social manager.
        /// </summary>
        private readonly SocialManager socialManager;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="channel"></param>
        public Player(IChannel channel)
        {
            this.channel = channel;
            interfaceManager = new InterfaceManager(this);
            socialManager = new SocialManager(this);
        }

        /// <summary>
        /// Initiates and starts the player.
        /// </summary>
        public void Start()
        {
            SendPacket(new StaticRegionContext(Position));
            interfaceManager.SendLoginDefaults();
            Refresh();
        }

        /// <summary>
        /// Refreshes the player.
        /// </summary>
        private void Refresh()
        {
            socialManager.SendGameMessage("Welcome to RuneScape.");
        }

        /// <summary>
        /// Sends a packet.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        public void SendPacket<T>(T context) where T : PacketContext
        {
            if (channel.Registered)
                GamePacketListener.SendGamePacket(channel, context);
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
        /// Gets the interface manager.
        /// </summary>
        /// <returns></returns>
        public InterfaceManager GetInterfaceManager()
        {
            return interfaceManager;
        }

        /// <summary>
        /// Gets the social manager.
        /// </summary>
        /// <returns></returns>
        public SocialManager GetSocialManager()
        {
            return socialManager;
        }

    }
}
