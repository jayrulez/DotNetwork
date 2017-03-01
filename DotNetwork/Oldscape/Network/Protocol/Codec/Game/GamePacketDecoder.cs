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
    sealed class GamePacketDecoder : ReplayingDecoder<PacketDecoderState>
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
        /// Constructs a new object.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="isaac"></param>
        public GamePacketDecoder(Player player, Rand isaac) : base(PacketDecoderState.PACKET_ID)
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

            while (input.ReadableBytes > 0 && input.IsReadable())
            {
                switch (State)
                {
                    case PacketDecoderState.PACKET_ID:
                        id = (input.ReadByte()/* - isaac.val()*/) & 0xff;
                        if (id >= PacketConstants.PACKET_SIZES.Length || id < 0)
                            break;
                        Checkpoint(PacketDecoderState.PACKET_SIZE);
                        break;
                    case PacketDecoderState.PACKET_SIZE:
                        size = PacketConstants.PACKET_SIZES[id];
                        if (size < 0)
                        {
                            switch (size)
                            {
                                case -1:
                                    if (input.IsReadable())
                                        size = input.ReadByte() & 0xff;
                                    break;
                                case -2:
                                    if (input.ReadableBytes >= 2)
                                        size = input.ReadUnsignedShort();
                                    break;
                                default:
                                    size = input.ReadableBytes;
                                    break;
                            }
                        }
                        Checkpoint(PacketDecoderState.PACKET_PAYLOAD);
                        break;
                    case PacketDecoderState.PACKET_PAYLOAD:
                        if (input.ReadableBytes >= size)
                        {
                            if (size < 0)
                                return;
                            byte[] payload = new byte[size];
                            input.ReadBytes(payload, 0, size);
                            output.Add(new GamePacketRequest(player, id, Unpooled.WrappedBuffer(payload)));
                        }
                        Checkpoint(PacketDecoderState.PACKET_ID);
                        break;
                }
            }

        }

    }
}
