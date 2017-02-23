// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl
{

    /// <summary>
    /// The context for the root interface packet.
    /// </summary>
    sealed class RootInterfaceContext : PacketContext
    {

        /// <summary>
        /// The interface id.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="id"></param>
        public RootInterfaceContext(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Gets the interface id.
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return id;
        }

    }
}
