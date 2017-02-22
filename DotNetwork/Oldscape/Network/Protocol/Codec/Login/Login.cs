// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using System.Linq;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Login
{

    /// <summary>
    /// The login.
    /// </summary>
    sealed class Login
    {

        /// <summary>
        /// Gets a login type.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static LoginType GetLoginType(int id)
        {
            return ((LoginType[])Enum.GetValues(typeof(LoginType))).FirstOrDefault(a => (int)a == id);
        }
    }

    /// <summary>
    /// An enumeration of the different login types.
    /// </summary>
    enum LoginType
    {

        /// <summary>
        /// Login opcode not supported.
        /// </summary>
        NONE,

        /// <summary>
        /// The new login connection.
        /// </summary>
        NEW_CONNECTION = 16,

        /// <summary>
        /// The reconnecting login connection.
        /// </summary>
        RECONNECTING_LOGIN = 18
    }
}
