// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using Burtleburtle;

namespace DotNetwork.Oldscape.Util.Isaac
{

    /// <summary>
    /// The two isaac random generated seeds for packet encoding and decoding.
    /// </summary>
    sealed class IsaacRandGroup
    {

        /// <summary>
        /// The isaac cipher decoder.
        /// </summary>
        private readonly Rand decoder;

        /// <summary>
        /// The isaac cipher encoder.
        /// </summary>
        private readonly Rand encoder;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="decoder"></param>
        /// <param name="encoder"></param>
        public IsaacRandGroup(Rand decoder, Rand encoder)
        {
            this.decoder = decoder;
            this.encoder = encoder;
        }

        /// <summary>
        /// Gets the isaac random decoder.
        /// </summary>
        /// <returns></returns>
        public Rand GetDecoderRand()
        {
            return decoder;
        }

        /// <summary>
        /// Gets the isaac random encoder.
        /// </summary>
        /// <returns></returns>
        public Rand GetEncoderRand()
        {
            return encoder;
        }

    }
}
