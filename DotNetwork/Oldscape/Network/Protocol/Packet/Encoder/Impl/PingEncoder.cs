// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder.Impl
{

    /// <summary>
    /// The ping packet encoder.
    /// </summary>
    sealed class PingEncoder : PacketEncoder<PingContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public PingEncoder() : base(244, PacketType.FIXED) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="context"></param>
        public override void Encode(PingContext context)
        {
            //Nothing as nothing is actually sent to the client except the packet id.
        }
    }
}
