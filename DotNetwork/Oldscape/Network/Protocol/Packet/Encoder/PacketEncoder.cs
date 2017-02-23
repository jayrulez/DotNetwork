// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Buffers;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder
{

    /// <summary>
    /// An abstract class used for the different packet encoders.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class PacketEncoder<T> where T : PacketContext
    {

        /// <summary>
        /// The packet id.
        /// </summary>
        protected readonly int id;

        /// <summary>
        /// The packet type.
        /// </summary>
        protected readonly PacketType type;

        /// <summary>
        /// The packet builder used for building encoded packets.
        /// </summary>
        protected readonly PacketBuilder builder;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public PacketEncoder(int id, PacketType type)
        {
            this.id = id;
            this.type = type;
            builder = new PacketBuilder(Unpooled.Buffer());
        }

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        public PacketEncoder(int id, PacketType type, int size)
        {
            this.id = id;
            this.type = type;
            builder = new PacketBuilder(Unpooled.Buffer(size));
        }

        /// <summary>
        /// Encodes a implemented packet.
        /// </summary>
        /// <param name="context"></param>
        public abstract void Encode(T context);

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
            return type;
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
