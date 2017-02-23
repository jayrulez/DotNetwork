// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Network.Protocol.Packet;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context;
using DotNetwork.Oldscape.Network.Protocol.Packet.Encoder;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Game
{
    sealed class GamePacketResponse
    {

        /// <summary>
        /// The packet id.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// The packet type.
        /// </summary>
        private readonly PacketType packetType;

        /// <summary>
        /// The packet builder.
        /// </summary>
        private readonly PacketBuilder builder;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="packetType"></param>
        /// <param name="builder"></param>
        public GamePacketResponse(int id, PacketType packetType, PacketBuilder builder)
        {
            this.id = id;
            this.packetType = packetType;
            this.builder = builder;
        }

        /// <summary>
        /// Gets the packet id.
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Gets the packet type.
        /// </summary>
        /// <returns></returns>
        public PacketType GetPacketType()
        {
            return packetType;
        }

        /// <summary>
        /// Gets the packet builder.
        /// </summary>
        /// <returns></returns>
        public PacketBuilder GetBuilder()
        {
            return builder;
        }

    }
}
