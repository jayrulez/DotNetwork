// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Game.Model.Inter.Impl
{

    /// <summary>
    /// The default interface listener if the repository can't find a listener for a clicked interface button.
    /// </summary>
    sealed class DefaultInterfaceListener : InterfaceListener
    {

        /// <summary>
        /// Executes the listener.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="interfaceId"></param>
        /// <param name="buttonId"></param>
        /// <param name="slot"></param>
        /// <param name="item"></param>
        public void Execute(Player player, int interfaceId, int buttonId, int slot, int item)
        {
            Console.WriteLine($"Interface listener not found: Interface[{interfaceId}], Button[{buttonId}], Slot[{slot}], Item[{item}]");
        }

        /// <summary>
        /// Gets the interface id.
        /// </summary>
        /// <returns></returns>
        public int GetInterfaceId()
        {
            return -1;
        }
    }
}
