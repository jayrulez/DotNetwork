// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Login
{

    /// <summary>
    /// The login response.
    /// </summary>
    sealed class LoginResponse
    {

        /// <summary>
        /// The connection message response.
        /// </summary>
        private readonly ConnectionMessage response;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="response"></param>
        public LoginResponse(ConnectionMessage response)
        {
            this.response = response;
        }

        /// <summary>
        /// Gets the connection message response.
        /// </summary>
        /// <returns></returns>
        public ConnectionMessage GetResponse()
        {
            return response;
        }

    }
}
