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
        /// The version of the client requesting handshake.
        /// </summary>
        private readonly int version;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="version"></param>
        public HandshakeRequest(int version)
        {
            this.version = version;
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
