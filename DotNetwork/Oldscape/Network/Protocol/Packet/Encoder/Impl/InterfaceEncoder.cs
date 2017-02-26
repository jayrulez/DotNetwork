// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder.Impl
{

    /// <summary>
    /// The interface packet encoder.
    /// </summary>
    sealed class InterfaceEncoder : PacketEncoder<InterfaceContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public InterfaceEncoder() : base(66, PacketType.FIXED) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="context"></param>
        public override void Encode(InterfaceContext context)
        {
            builder.Put(DataType.SHORT, context.GetInterfaceId());
            builder.Put(DataType.INT, DataOrder.MIDDLE, context.GetRootId() << 16 | context.GetChildId());
            builder.Put(DataType.BYTE, DataTransformation.SUBTRACT, context.IsOverlay() ? 1 : 0);
        }
    }
}
