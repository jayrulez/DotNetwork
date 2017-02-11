// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using System.Linq;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Handshake
{

    /// <summary>
    /// The handshake.
    /// </summary>
    sealed class Handshake
    {
        /// <summary>
        /// Gets a handshake type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static HandshakeType GetHandshakeType(int id)
        {
            return ((HandshakeType[])Enum.GetValues(typeof(HandshakeType))).FirstOrDefault(a => (int)a == id);
        }
    }

    /// <summary>
    /// The handshake types.
    /// </summary>
    enum HandshakeType
    {
        /// <summary>
        /// Unsupported handshake opcode.
        /// </summary>
        NONE,

        /// <summary>
        /// The update connection type.
        /// </summary>
        UPDATE_CONNECTION = 15,

        /// <summary>
        /// The login connection type.
        /// </summary>
        LOGIN_CONNECTION = 14
    }
}
