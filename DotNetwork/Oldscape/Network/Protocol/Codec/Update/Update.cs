// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using System.Linq;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Update
{

    /// <summary>
    /// The update.
    /// </summary>
    sealed class Update
    {
        /// <summary>
        /// Gets a update request type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UpdateType GetUpdateType(int id)
        {
            return ((UpdateType[])Enum.GetValues(typeof(UpdateType))).FirstOrDefault(a => (int)a == id);
        }
    }

    /// <summary>
    /// The update request types.
    /// </summary>
    enum UpdateType
    {
        /// <summary>
        /// Unsupported update type opcode.
        /// </summary>
        NONE,

        /// <summary>
        /// Low priority file request.
        /// </summary>
        LOW_PRIORITY_UPDATE = 0,

        /// <summary>
        /// High priority file request.
        /// </summary>
        HIGH_PRIORITY_UPDATE = 1,

        /// <summary>
        /// File encryption request.
        /// </summary>
        ENCRYPTION_UPDATE = 4
    }
}
