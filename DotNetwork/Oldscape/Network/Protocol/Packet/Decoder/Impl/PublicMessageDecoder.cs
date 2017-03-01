// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Decoder.Impl
{

    /// <summary>
    /// The public message decoder.
    /// </summary>
    sealed class PublicMessageDecoder : PacketDecoder
    {

        /// <summary>
        /// Decodes the packet.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        public void Decode(Player player, int id, PacketReader reader)
        {

            reader.GetUnsigned(DataType.BYTE);
            reader.GetUnsigned(DataType.BYTE);
            reader.GetUnsigned(DataType.BYTE);
            reader.getUnsignedSmart();
        }

        /// <summary>
        /// Gets the packet ids.
        /// </summary>
        /// <returns></returns>
        public int[] GetPacketIds()
        {
            return new int[] { 55 };
        }
    }
}
