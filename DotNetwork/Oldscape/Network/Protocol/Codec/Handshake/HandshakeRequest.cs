// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Handshake
{

    /// <summary>
    /// The handshake message.
    /// </summary>
    sealed class HandshakeRequest
    {
        /// <summary>
        /// The handshake type.
        /// </summary>
        private readonly HandshakeType type;

        /// <summary>
        /// The version of the client requesting handshake.
        /// </summary>
        private readonly int version;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="version"></param>
        public HandshakeRequest(HandshakeType type, int version)
        {
            this.type = type;
            this.version = version;
        }

        /// <summary>
        /// Gets the handshake type.
        /// </summary>
        /// <returns></returns>
        public HandshakeType GetHandshakeType()
        {
            return type;
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns></returns>
        public int GetVersion()
        {
            return version;
        }
    }
}
