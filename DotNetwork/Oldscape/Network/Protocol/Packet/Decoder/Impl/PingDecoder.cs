// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Decoder.Impl
{

    /// <summary>
    /// The keep alive decoder packet.
    /// </summary>
    sealed class PingDecoder : PacketDecoder
    {

        /// <summary>
        /// Decodes the packet.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        public void Decode(Player player, int id, PacketReader reader)
        {
            player.SendPacket(new PingContext());
        }

        /// <summary>
        /// Gets the packet ids.
        /// </summary>
        /// <returns></returns>
        public int[] GetPacketIds()
        {
            return new int[] { 132 };
        }
    }
}
