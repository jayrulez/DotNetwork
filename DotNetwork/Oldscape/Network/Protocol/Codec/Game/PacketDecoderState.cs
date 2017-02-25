// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Game
{

    /// <summary>
    /// The state of decoding a packet.
    /// </summary>
    enum PacketDecoderState
    {

        /// <summary>
        /// Decode the packet id.
        /// </summary>
        PACKET_ID,

        /// <summary>
        /// Decode the packet size.
        /// </summary>
        PACKET_SIZE,

        /// <summary>
        /// Decode the payload.
        /// </summary>
        PACKET_PAYLOAD

    }
}
