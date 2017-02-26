// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;

namespace DotNetwork.Oldscape.Game.Model.Inter
{

    /// <summary>
    /// A listener for interface button actions.
    /// </summary>
    interface InterfaceListener
    {

        /// <summary>
        /// Executes a interface listener.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="interfaceId"></param>
        /// <param name="buttonId"></param>
        /// <param name="slot"></param>
        /// <param name="item"></param>
        void Execute(Player player, int interfaceId, int buttonId, int slot, int item);

        /// <summary>
        /// Gets the interface id that is used for each specific interface listener.
        /// </summary>
        /// <returns></returns>
        int GetInterfaceId();

    }
}
