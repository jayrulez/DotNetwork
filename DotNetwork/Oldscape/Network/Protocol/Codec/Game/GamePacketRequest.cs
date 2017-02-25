// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Buffers;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Game
{

    /// <summary>
    /// The game packet request.
    /// </summary>
    sealed class GamePacketRequest
    {

        /// <summary>
        /// The player.
        /// </summary>
        private readonly Player player;

        /// <summary>
        /// The packet id.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// The decoded payload.
        /// </summary>
        private readonly IByteBuffer payload;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="id"></param>
        /// <param name="payload"></param>
        public GamePacketRequest(Player player, int id, IByteBuffer payload)
        {
            this.player = player;
            this.id = id;
            this.payload = payload;
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer()
        {
            return player;
        }

        /// <summary>
        /// Gets the packet id.
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Gets the buffer payload.
        /// </summary>
        /// <returns></returns>
        public IByteBuffer GetPayload()
        {
            return payload;
        }

    }
}
