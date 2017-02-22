// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network;
using DotNetwork.Oldscape.Network.Protocol.CacheFS;
using System;

namespace DotNetwork.Oldscape
{

    /// <summary>
    /// 
    /// </summary>
    sealed class Server
    {

        /// <summary>
        /// The version of the server.
        /// </summary>
        public const int VERSION = 103;

        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to DotNetwork.");
            Console.WriteLine("A fast and lightweight C# emulation g1ame network for the RuneTek engine.");

            Console.WriteLine("Loading the cache...");
            CacheManager.Load();

            Console.WriteLine("Starting the network...");
            NetworkBootstrap.StartNetwork();

            GC.Collect();
            Console.WriteLine("Online!");

            //To keep the server from closing.
            while (true)
            {
                if (Console.ReadLine().Equals("close"))
                    break;
            }
        }
    }
}
