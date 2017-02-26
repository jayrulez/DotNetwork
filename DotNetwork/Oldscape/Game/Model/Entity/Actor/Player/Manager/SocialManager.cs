// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;
using System;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Manager
{

    /// <summary>
    /// The social manager.
    /// </summary>
    sealed class SocialManager
    {

        /// <summary>
        /// The player.
        /// </summary>
        private readonly Player player;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="player"></param>
        public SocialManager(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Sends a game message.
        /// </summary>
        /// <param name="message"></param>
        public void SendGameMessage(string message)
        {
            player.SendPacket(new MessageContext(0, message, false));
        }

    }
}
