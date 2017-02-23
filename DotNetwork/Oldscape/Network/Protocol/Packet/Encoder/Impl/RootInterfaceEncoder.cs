// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder.Impl
{

    /// <summary>
    /// THe root interface packet encoder.
    /// </summary>
    sealed class RootInterfaceEncoder : PacketEncoder<RootInterfaceContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public RootInterfaceEncoder() : base(208, PacketType.FIXED) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="context"></param>
        public override void Encode(Player player, RootInterfaceContext context)
        {
            builder.Put(DataType.SHORT, DataOrder.LITTLE, context.GetId());
        }
    }
}
