// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl
{

    /// <summary>
    /// The context used for updating a player.
    /// </summary>
    sealed class PlayerUpdateContext : PacketContext
    {

        /// <summary>
        /// The player.
        /// </summary>
        private readonly Player player;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="player"></param>
        public PlayerUpdateContext(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer()
        {
            return player;
        }

    }
}
