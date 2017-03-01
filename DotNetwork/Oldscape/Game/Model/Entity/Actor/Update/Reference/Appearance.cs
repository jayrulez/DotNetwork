// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Update.Reference
{

    /// <summary>
    /// The appearance.
    /// </summary>
    sealed class Appearance
    {

        /// <summary>
        /// The default appearance.
        /// </summary>
        public static readonly Appearance DEFAULT_APPEARANCE = new Appearance(Gender.MALE, new int[] { 0, 10, 18, 26, 33, 36, 42 }, new int[] { 15, 71, -38, 4, 1 });

        /// <summary>
        /// The gender of the apprarance.
        /// </summary>
        private readonly Gender gender;

        /// <summary>
        /// The appearance styles.
        /// </summary>
        private readonly int[] styles;

        /// <summary>
        /// The appearance colors.
        /// </summary>
        private readonly int[] colors;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="styles"></param>
        /// <param name="colors"></param>
        public Appearance(Gender gender, int[] styles, int[] colors)
        {
            this.gender = gender;
            this.styles = styles;
            this.colors = colors;
        }

        /// <summary>
        /// Gets the gender.
        /// </summary>
        /// <returns></returns>
        public Gender GetGender()
        {
            return gender;
        }

        /// <summary>
        /// Gets the styles.
        /// </summary>
        /// <returns></returns>
        public int[] GetStyles()
        {
            return styles;
        }

        /// <summary>
        /// Gets the colors.
        /// </summary>
        /// <returns></returns>
        public int[] GetColors()
        {
            return colors;
        }

    }

    /// <summary>
    /// Represents a gender.
    /// </summary>
    enum Gender
    {

        /// <summary>
        /// The male gender and mask.
        /// </summary>
        MALE = 0x0,

        /// <summary>
        /// The female gender and mask.
        /// </summary>
        FEMALE = 0x1

    }
}
