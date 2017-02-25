// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Packet
{

    /// <summary>
    /// The packet constants.
    /// </summary>
    sealed class PacketConstants
    {

        /// <summary>
        /// An array of the packet decoder sizes.
        /// </summary>
        public static readonly int[] PACKET_SIZES = new int[] { 8, 7, -1, 6, 0, 7, 9, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, -1, 0, 4, 8, 0, 0, 0, 0, 0, 0, 3, -1, 0, 0, 0, 12, 3, 8, 0, 8, -1, 0, 3, 3, 0, 0, 5, 0, 0, 0, 16, 0, 0, 15, 0, 4, 3, 7, 0, 0, 0, 0, 0, 8, 8, 13, 0, 0, 8, 4, 0, 0, 0, 0, -1, 0, 0, 0, 0, 4, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 3, 0, 0, 8, 0, 2, 0, -1, 0, 0, 9, 8, 0, 0, 0, 0, 0, -1, 5, 0, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 8, 8, 9, 0, 0, 8, 0, 0, 13, -1, 8, 8, 0, 19, 0, 0, 0, 7, 7, 0, 0, 0, 11, -1, 0, 0, 0, 0, 16, 6, 0, -1, -1, 0, 0, 8, 7, 0, 0, 0, 7, 0, 0, 0, 0, 0, 8, 0, 0, 0, 8, 0, 0, 0, 2, 0, -1, 0, 2, 0, 3, 0, 0, 0, 3, 0, 0, 8, 0, 0, 7, 0, 0, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 11, 13, 0, -1, 0, 0, 15, 3, 0, -1, 0, 0, 0, 8, -1, 0, 0, 7, 3, 0, 0, 0, 0, 8 };

        /// <summary>
        /// Gets the packet type based on the packet id from the client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PacketType GetPacketType(int id)
        {
            foreach (int size in PACKET_SIZES)
            {
                if (size == PACKET_SIZES[id])
                {
                    if (size == -2)
                        return PacketType.VARIABLE_SHORT;
                    else if (size == -1)
                        return PacketType.VARIABLE_BYTE;
                    else
                        return PacketType.FIXED;
                }
            }
            return PacketType.NONE;
        }

    }
}
