// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Game.World.Region
{

    /// <summary>
    /// The position location for each entity.
    /// </summary>
    sealed class Position
    {

        /// <summary>
        /// The x coordinate.
        /// </summary>
        private readonly int x;

        /// <summary>
        /// The y coordinate.
        /// </summary>
        private readonly int y;

        /// <summary>
        /// The height.
        /// </summary>
        private readonly int height;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="position"></param>
        public Position(Position position) : this(position.x, position.y, position.height) { }

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        public Position(int x, int y, int height)
        {
            this.x = x;
            this.y = y;
            this.height = height;
        }

        /// <summary>
        /// Gets the unique hash of the current position.
        /// </summary>
        /// <returns></returns>
        public int GetPositionHash()
        {
            return y + (x << 14) + (height << 28);
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetX()
        {
            return x;
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetY()
        {
            return y;
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <returns></returns>
        public int GetHeight()
        {
            return height;
        }

    }
}
