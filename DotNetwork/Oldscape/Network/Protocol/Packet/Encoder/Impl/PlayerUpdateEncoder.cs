// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder.Impl
{

    /// <summary>
    /// The player update packet encoder.
    /// </summary>
    sealed class PlayerUpdateEncoder : PacketEncoder<PlayerUpdateContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public PlayerUpdateEncoder() : base(129, PacketType.VARIABLE_SHORT) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="context"></param>
        public override void Encode(PlayerUpdateContext context)
        {
            builder.PutBytes(PlayerUpdate.Update(context.GetPlayer()).GetBuffer());
        }
    }
}
