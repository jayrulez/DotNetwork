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
            output.WriteBytes(GetData(message));
        }

        /// <summary>
        /// Gets the encoded data of a packet.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private IByteBuffer GetData(GamePacketResponse message)
        {
            var type = message.GetPacketType();
            var payload = message.GetBuilder().GetBuffer();
            int bytes = payload.ReadableBytes;

            var buffer = Unpooled.Buffer(bytes);
            buffer.WriteByte(message.GetId() + isaac.val());
            if (type == PacketType.VARIABLE_BYTE)
            {
                if (bytes >= 256)
                    throw new Exception("Payload too long for variable byte packet.");
                buffer.WriteByte(bytes);
            }
            else if (type == PacketType.VARIABLE_SHORT)
            {
                if (bytes >= 65536)
                    throw new Exception("Payload too long for variable short packet.");
                buffer.WriteShort(bytes);
            }
            buffer.WriteBytes(payload);
            return buffer;
        }

    }
}
