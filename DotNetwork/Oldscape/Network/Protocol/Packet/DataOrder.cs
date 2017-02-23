// Copyright(c) 2010-2011 Graham Edgecombe
// Copyright(c) 2011-2016 Major<major.emrs@gmail.com> and other apollo contributors
//
// Permission to use, copy, modify, and/or distribute this software for any
// purpose with or without fee is hereby granted, provided that the above
// copyright notice and this permission notice appear in all copies.
//
//
// THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
// WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
// MERCHANTABILITY AND FITNESS.IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
// ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
// WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
// ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
// OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

namespace DotNetwork.Oldscape.Network.Protocol.Packet
{

    /// <summary>
    /// The order of bytes in a data type.
    /// </summary>
    enum DataOrder
    {

        /// <summary>
        /// Most significant byte to least significant byte.
        /// </summary>
        BIG,

        /// <summary>
        /// Also known as the V2 order.
        /// </summary>
        INVERSED_MIDDLE,

        /// <summary>
        /// Least significant byte to most significant byte.
        /// </summary>
        LITTLE,

        /// <summary>
        /// Also known as the V1 order.
        /// </summary>
        MIDDLE

    }
}
