// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Update.Encoder
{

    /// <summary>
    /// A encoder parent class for all the different update blocks.
    /// </summary>
    /// <typeparam name="A"></typeparam>
    abstract class UpdateBlock<A> where A : Actor
    {

        /// <summary>
        /// The ordinal index of the inherited block.
        /// </summary>
        protected readonly int ordinal;

        /// <summary>
        /// The mask id of the block.
        /// </summary>
        protected readonly int mask;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="ordinal"></param>
        /// <param name="mask"></param>
        public UpdateBlock(int ordinal, int mask)
        {
            this.ordinal = ordinal;
            this.mask = mask;
        }

        /// <summary>
        /// Encodes a update block.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="builder"></param>
        public abstract void EncodeBlock(A actor, PacketBuilder builder);

        /// <summary>
        /// Gets the oridinal.
        /// </summary>
        /// <returns></returns>
        public int GetOrdinal()
        {
            return ordinal;
        }

        /// <summary>
        /// Gets the mask.
        /// </summary>
        /// <returns></returns>
        public int GetMask()
        {
            return mask;
        }

    }
}
