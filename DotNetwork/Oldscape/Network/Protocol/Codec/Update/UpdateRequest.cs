// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Update
{

    /// <summary>
    /// The update request.
    /// </summary>
    sealed class UpdateRequest
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
        /// Constructs a new object.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="archive"></param>
        /// <param name="priority"></param>
        public UpdateRequest(int index, int archive, bool priority)
        {
            this.index = index;
            this.archive = archive;
            this.priority = priority;
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
    }
}
