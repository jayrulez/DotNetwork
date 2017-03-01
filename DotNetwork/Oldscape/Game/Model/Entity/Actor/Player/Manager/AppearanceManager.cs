// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Block;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Update.Reference;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Manager
{

    /// <summary>
    /// The appearance manager.
    /// </summary>
    sealed class AppearanceManager
    {

        /// <summary>
        /// The player.
        /// </summary>
        private readonly Player player;

        /// <summary>
        /// The appearance.
        /// </summary>
        private readonly Appearance appearance;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="player"></param>
        public AppearanceManager(Player player)
        {
            this.player = player;
            appearance = Appearance.DEFAULT_APPEARANCE;
        }

        /// <summary>
        /// Refreshes the player appearance.
        /// </summary>
        public void Refresh()
        {
            player.GetActorRenderer().Flag(new AppearanceBlock());
        }

        /// <summary>
        /// Gets the appearance.
        /// </summary>
        /// <returns></returns>
        public Appearance GetAppearance()
        {
            return appearance;
        }

    }
}
