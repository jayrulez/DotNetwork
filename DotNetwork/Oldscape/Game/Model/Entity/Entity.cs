// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.World.Region;

namespace DotNetwork.Oldscape.Game.Model.Entity
{

    /// <summary>
    /// The game entity.
    /// </summary>
    abstract class Entity
    {

        /// <summary>
        /// The position of the entity.
        /// </summary>
        private Position position;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="position"></param>
        public Entity(Position position)
        {
            this.position = position;
        }

        /// <summary>
        /// Gets and sets the position.
        /// </summary>
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
