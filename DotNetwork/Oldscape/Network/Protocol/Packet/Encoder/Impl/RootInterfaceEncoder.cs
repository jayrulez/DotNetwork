// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder.Impl
{

    /// <summary>
    /// The root interface packet encoder.
    /// </summary>
    sealed class RootInterfaceEncoder : PacketEncoder<RootInterfaceContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public RootInterfaceEncoder() : base(108, PacketType.FIXED) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="context"></param>
        public override void Encode(RootInterfaceContext context)
        {
            builder.Put(DataType.SHORT, DataOrder.LITTLE, DataTransformation.ADD, context.GetId());
        }

    }
}
