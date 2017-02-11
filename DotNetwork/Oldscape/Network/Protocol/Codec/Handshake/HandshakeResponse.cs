// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Handshake
{

    /// <summary>
    /// The handshake response.
    /// </summary>
    sealed class HandshakeResponse
    {

        /// <summary>
        /// The handshake type.
        /// </summary>
        private HandshakeType type;

        /// <summary>
        /// The connection message response.
        /// </summary>
        private readonly ConnectionMessage response;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="response"></param>
        public HandshakeResponse(HandshakeType type, ConnectionMessage response)
        {
            this.type = type;
            this.response = response;
        }

        /// <summary>
        /// Gets the connection message.
        /// </summary>
        /// <returns></returns>
        public ConnectionMessage GetConnectionMessage()
        {
            return response;
        }

        /// <summary>
        /// Gets the handshake type.
        /// </summary>
        /// <returns></returns>
        public HandshakeType GetHandshakeType()
        {
            return type;
        }

    }
}
