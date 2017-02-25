// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Decoder
{

    /// <summary>
    /// An interface used for the different packet decoders.
    /// </summary>
    interface PacketDecoder
    {

        /// <summary>
        /// Decodes a packet from the client.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        void Decode(Player player, int id, PacketReader reader);

        /// <summary>
        /// Gets the packet ids associated with each packet decoder.
        /// </summary>
        /// <returns></returns>
        int[] GetPacketIds();

    }
}
