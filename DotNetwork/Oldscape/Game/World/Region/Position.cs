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
        /// Gets the local x coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetLocalX()
        {
            return (x - GetTopLeftSectorX() * 8);
        }

        /// <summary>
        /// Gets the local y coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetLocalY()
        {
            return (y - GetTopLeftSectorY() * 8);
        }

        /// <summary>
        /// Gets the top left sector x coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetTopLeftSectorX()
        {
            return (x / 8 - 6);
        }

        /// <summary>
        /// Gets the top left sector y coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetTopLeftSectorY()
        {
            return (y / 8 - 6);
        }

        /// <summary>
        /// Gets the central sector x coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetCentralSectorX()
        {
            return (x / 8);
        }

        /// <summary>
        /// Gets the central sector y coordinate.
        /// </summary>
        /// <returns></returns>
        public int GetCentralSectorY()
        {
            return (y / 8);
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
