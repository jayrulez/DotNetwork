// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Buffers;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Update
{

    /// <summary>
    /// The update response.
    /// </summary>
    class UpdateResponse
    {
        /// <summary>
        /// The index.
        /// </summary>
        private readonly int index;

        /// <summary>
        /// The archive.
        /// </summary>
        private readonly int archive;

        /// <summary>
        /// The priority.
        /// </summary>
        private readonly bool priority;

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IByteBuffer container;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="archive"></param>
        /// <param name="priority"></param>
        /// <param name="container"></param>
        public UpdateResponse(int index, int archive, bool priority, IByteBuffer container)
        {
            this.index = index;
            this.archive = archive;
            this.priority = priority;
            this.container = container;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns></returns>
        public int GetIndex()
        {
            return index;
        }

        /// <summary>
        /// Gets the archive.
        /// </summary>
        /// <returns></returns>
        public int GetArchive()
        {
            return archive;
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <returns></returns>
        public bool IsPriority()
        {
            return priority;
        }

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <returns></returns>
        public IByteBuffer GetContainer()
        {
            return container;
        }

    }
}
