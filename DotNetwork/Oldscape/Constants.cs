// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;

namespace DotNetwork.Oldscape
{

    /// <summary>
    /// Constants used throughout the envrionment.
    /// </summary>
    sealed class Constants
    {

        /// <summary>
        /// The base namespace packaging presentation.
        /// </summary>
        public const string NAMESPACE_PRESENTATION = "DotNetwork.Oldscape";

        /// <summary>
        /// The cache directory.
        /// </summary>
        public static readonly string CACHE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Visual Studio 2015/Projects/DotNetwork/Cache/";

        /// <summary>
        /// The server address ip.
        /// </summary>
        public const string SERVER_IP = "127.0.0.1";

        /// <summary>
        /// The server port.
        /// </summary>
        public const int SERVER_PORT = 43594;

        /// <summary>
        /// The unique gamepack token.
        /// </summary>
        public const string GAMEPACK_TOKEN = "ElZAIrq5NpKN6D3mDdihco3oPeYN2KFy2DCquj7JMmECPmLrDP3Bnw";

        /// <summary>
        /// The maximum number of players allowed inside the game world.
        /// </summary>
        public const int MAX_PLAYERS = 2048;

    }
}
