// Copyright(c) 2010-2011 Graham Edgecombe

using System;
using System.Collections.Generic;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using Burtleburtle;
using DotNetwork.Oldscape.Network.Protocol.Packet;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Game
{

    /// <summary>
    /// The packet decoder.
    /// </summary>
    sealed class GamePacketDecoder : ByteToMessageDecoder
    {

        /// <summary>
        /// The player.
        /// </summary>
        private readonly Player player;

        /// <summary>
        /// The isaac random decoder.
        /// </summary>
        private readonly Rand isaac;

        /// <summary>
        /// The packet id.
        /// </summary>
        private int id;

        /// <summary>
        /// The packet size.
        /// </summary>
        private int size;

        /// <summary>
        /// The packet type.
        /// </summary>
        private PacketType type;

        /// <summary>
        /// The state of a current packet decoder.
        /// </summary>
        private PacketDecoderState state = PacketDecoderState.PACKET_ID;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="isaac"></param>
        public GamePacketDecoder(Player player, Rand isaac)
        {
            this.player = player;
            this.isaac = isaac;
        }

        /// <summary>
        /// Decodes a game packet from the client.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input"></param>
        /// <param name="output"></param>
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            if (!input.IsReadable() || !player.GetChannel().Registered)
                return;

            //Decode packet id.
            if (state == PacketDecoderState.PACKET_ID)
            {
                id = input.ReadByte();
                if (id > PacketConstants.PACKET_SIZES.Length)
                    throw new Exception("Invalid packet id: " + id);
                size = PacketConstants.PACKET_SIZES[id];

                type = PacketConstants.GetPacketType(id);
                if (type == PacketType.NONE)
                    throw new Exception("Packet type not found for id: " + id);

                state = type != PacketType.FIXED ? PacketDecoderState.PACKET_SIZE : PacketDecoderState.PACKET_PAYLOAD;
            }

            //Decode packet size.
            if (state == PacketDecoderState.PACKET_SIZE)
            {
                if (type == PacketType.VARIABLE_BYTE)
                    size = input.ReadByte();
                else if (type == PacketType.VARIABLE_SHORT)
                {
                    if (input.ReadableBytes >= 2)
                        size = input.ReadUnsignedShort();
                }

                state = PacketDecoderState.PACKET_PAYLOAD;
            }

            //Decode payload.
            if (state == PacketDecoderState.PACKET_PAYLOAD)
            {
                if (input.ReadableBytes < size)
                    return;

                IByteBuffer payload = input.ReadBytes(size);
                state = PacketDecoderState.PACKET_ID;

                output.Add(new GamePacketRequest(player, id, payload));
            }

        }

    }
}
