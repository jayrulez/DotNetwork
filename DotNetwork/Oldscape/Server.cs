﻿// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Inter;
using DotNetwork.Oldscape.Network;
using DotNetwork.Oldscape.Network.Protocol.CacheFS;
using DotNetwork.Oldscape.Network.Protocol.Packet;
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
        public const int VERSION = 83;

        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <param name="args"></param>
        public static void Main()
        {
            Console.WriteLine("Welcome to DotNetwork.");
            Console.WriteLine("A fast and lightweight C# emulation game network for the RuneTek engine.");

            Console.WriteLine("Loading the cache...");
            CacheManager.Load();

            Console.WriteLine($"Registered {PacketRepository.PACKET_ENCODERS.Count} packet encoder(s).");
            Console.WriteLine($"Registered {PacketRepository.PACKET_DECODERS.Count} packet decoder(s).");
            Console.WriteLine($"Registered {InterfaceListenerRepository.INTERFACE_LISTENERS.Count} interface listener(s).");

            Console.WriteLine("Starting the network...");
            NetworkBootstrap.StartNetwork();

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
