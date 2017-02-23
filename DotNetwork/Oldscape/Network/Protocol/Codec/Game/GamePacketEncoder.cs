// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Burtleburtle;
using DotNetwork.Oldscape.Network.Protocol.Packet;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Game
{

    /// <summary>
    /// The packet encoder.
    /// </summary>
    sealed class GamePacketEncoder : MessageToByteEncoder<GamePacketResponse>
    {

        /// <summary>
        /// The isaac random encoder.
        /// </summary>
        private readonly Rand isaac;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="isaac"></param>
        public GamePacketEncoder(Rand isaac)
        {
            this.isaac = isaac;
        }

        /// <summary>
        /// Encodes a game packet to the client.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <param name="output"></param>
        protected override void Encode(IChannelHandlerContext context, GamePacketResponse message, IByteBuffer output)
        {
            var type = message.GetPacketType();
            var buffer = message.GetBuilder().GetBuffer();

            output.WriteByte(message.GetId() + isaac.val());
            if (type == PacketType.VARIABLE_BYTE)
                output.WriteByte(buffer.WriterIndex);
            else if (type == PacketType.VARIABLE_SHORT)
                output.WriteShort(buffer.WriterIndex);

            output.WriteBytes(buffer);
        }

    }
}
