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
        /// The renderer used for each actor inside the game.
        /// </summary>
        protected readonly ActorRenderer actorRenderer;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public Actor() : base(GameWorld.DEFAULT_POSITION)
        {
            actorRenderer = new ActorRenderer();
        }

        /// <summary>
        /// Gets the actor renderer.
        /// </summary>
        /// <returns></returns>
        public ActorRenderer GetActorRenderer()
        {
            return actorRenderer;
        }

    }
}
