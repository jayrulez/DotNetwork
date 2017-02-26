// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder.Impl
{

    /// <summary>
    /// The message packet encoder.
    /// </summary>
    sealed class MessageEncoder : PacketEncoder<MessageContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public MessageEncoder() : base(79, PacketType.VARIABLE_BYTE) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="context"></param>
        public override void Encode(MessageContext context)
        {
            builder.PutSmart(context.GetChannelType());
            builder.Put(DataType.BYTE, 0);
            builder.PutString(context.GetMessage());
        }
    }
}
