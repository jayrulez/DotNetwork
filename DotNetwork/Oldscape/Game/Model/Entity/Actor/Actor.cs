// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.World;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor
{

    /// <summary>
    /// The game actor.
    /// </summary>
    abstract class Actor : Entity
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public Actor() : base(GameWorld.DEFAULT_POSITION) { }

    }
}
