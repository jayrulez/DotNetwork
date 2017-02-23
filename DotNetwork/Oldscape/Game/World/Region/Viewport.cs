// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet;

namespace DotNetwork.Oldscape.Game.World.Region
{

    /// <summary>
    /// The actor viewport for the region.
    /// </summary>
    sealed class Viewport
    {

        /// <summary>
        /// The player.
        /// </summary>
        private readonly Player player;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="player"></param>
        public Viewport(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Initiates the viewport.
        /// </summary>
        /// <param name="builder"></param>
        public void Init(PacketBuilder builder)
        {
            builder.SwitchToBitAccess();
            builder.PutBits(30, player.Position.GetPositionHash());
        }

    }
}
