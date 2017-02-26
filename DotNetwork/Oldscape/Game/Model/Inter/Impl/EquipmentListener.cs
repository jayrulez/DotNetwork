// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

namespace DotNetwork.Oldscape.Game.Model.Inter.Impl
{

    /// <summary>
    /// The equipment interface listener.
    /// </summary>
    sealed class EquipmentListener : InterfaceListener
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
            if (buttonId == 17)
                player.GetInterfaceManager().SendInterface(84);
        }

        /// <summary>
        /// Gets the interface id.
        /// </summary>
        /// <returns></returns>
        public int GetInterfaceId()
        {
            return 387;
        }
    }
}
