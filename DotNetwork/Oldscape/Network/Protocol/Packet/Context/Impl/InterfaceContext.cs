// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl
{

    /// <summary>
    /// The open interface context.
    /// </summary>
    sealed class InterfaceContext : PacketContext
    {

        /// <summary>
        /// The root interface id.
        /// </summary>
        private readonly int rootId;

        /// <summary>
        /// The child id for the root interface.
        /// </summary>
        private readonly int childId;

        /// <summary>
        /// The interface id.
        /// </summary>
        private readonly int interfaceId;

        /// <summary>
        /// The overlay.
        /// </summary>
        private readonly bool overlay;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="rootId"></param>
        /// <param name="childId"></param>
        /// <param name="interfaceId"></param>
        /// <param name="overlay"></param>
        public InterfaceContext(int rootId, int childId, int interfaceId, bool overlay)
        {
            this.rootId = rootId;
            this.childId = childId;
            this.interfaceId = interfaceId;
            this.overlay = overlay;
        }

        /// <summary>
        /// Gets the root interface id.
        /// </summary>
        /// <returns></returns>
        public int GetRootId()
        {
            return rootId;
        }

        /// <summary>
        /// Gets the child id.
        /// </summary>
        /// <returns></returns>
        public int GetChildId()
        {
            return childId;
        }

        /// <summary>
        /// Gets the interface id.
        /// </summary>
        /// <returns></returns>
        public int GetInterfaceId()
        {
            return interfaceId;
        }

        /// <summary>
        /// Gets the overlay.
        /// </summary>
        /// <returns></returns>
        public bool IsOverlay()
        {
            return overlay;
        }

    }
}
