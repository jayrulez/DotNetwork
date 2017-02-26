// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Game.Model.Inter;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Decoder.Impl
{

    /// <summary>
    /// 
    /// </summary>
    sealed class ActionButtonDecoder : PacketDecoder
    {

        /// <summary>
        /// Decodes the packet.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="id"></param>
        /// <param name="reader"></param>
        public void Decode(Player player, int id, PacketReader reader)
        {
            int interfaceId = (int)reader.GetUnsigned(DataType.SHORT);
            int buttonId = (int)reader.GetUnsigned(DataType.SHORT);
            int slot = (int)reader.GetUnsigned(DataType.SHORT);
            int item = (int)reader.GetUnsigned(DataType.SHORT);
            if (slot == 65535)
                slot = 0;
            if (item == 65535)
                item = 0;
            InterfaceListenerRepository.GetInterfaceListener(interfaceId).Execute(player, interfaceId, buttonId, slot, item);
        }

        /// <summary>
        /// Gets the packet ids.
        /// </summary>
        /// <returns></returns>
        public int[] GetPacketIds()
        {
            return new int[] { 255, 149, 194, 148, 0, 245, 159 };
        }
    }
}
