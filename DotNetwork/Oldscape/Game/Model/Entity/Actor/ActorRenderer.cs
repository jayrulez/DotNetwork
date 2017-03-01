// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Update.Encoder;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor
{

    /// <summary>
    /// The renderer used for each actor inside the game.
    /// </summary>
    sealed class ActorRenderer
    {

        /// <summary>
        /// The updates block for a player.
        /// </summary>
        private readonly UpdateBlock<Player.Player>[] blocks;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public ActorRenderer()
        {
            blocks = new UpdateBlock<Player.Player>[30];
        }

        /// <summary>
        /// Flags an update block to be used.
        /// </summary>
        /// <param name="block"></param>
        public void Flag(UpdateBlock<Player.Player> block)
        {
            blocks[block.GetOrdinal()] = block;
        }

        /// <summary>
        /// Removes a update block.
        /// </summary>
        /// <param name="block"></param>
        public void Remove(UpdateBlock<Player.Player> block)
        {
            var current = blocks[block.GetOrdinal()] as UpdateBlock<Player.Player>;
            if (current != block)
                return;
            blocks[block.GetOrdinal()] = null;
        }

        /// <summary>
        /// Gets the update blocks.
        /// </summary>
        /// <returns></returns>
        public UpdateBlock<Player.Player>[] GetUpdateBlocks()
        {
            return blocks;
        }

    }
}
