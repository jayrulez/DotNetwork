// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.World.Region;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl
{

    /// <summary>
    /// The context used for static region updating.
    /// </summary>
    sealed class StaticRegionContext : PacketContext
    {

        /// <summary>
        /// The position to use.
        /// </summary>
        private readonly Position position;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="position"></param>
        public StaticRegionContext(Position position)
        {
            this.position = position;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns></returns>
        public Position GetPosition()
        {
            return position;
        }

    }
}
