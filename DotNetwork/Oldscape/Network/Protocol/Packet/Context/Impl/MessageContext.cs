// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl
{

    /// <summary>
    /// The message packet context.
    /// </summary>
    sealed class MessageContext : PacketContext
    {

        /// <summary>
        /// The message channel type.
        /// </summary>
        private readonly int type;

        /// <summary>
        /// The message.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// The filter.
        /// </summary>
        private readonly bool filter;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="filter"></param>
        public MessageContext(int type, string message, bool filter)
        {
            this.type = type;
            this.message = message;
            this.filter = filter;
        }

        /// <summary>
        /// Gets the message channel type.
        /// </summary>
        /// <returns></returns>
        public int GetChannelType()
        {
            return type;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            return message;
        }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <returns></returns>
        public bool IsFiltered()
        {
            return filter;
        }

    }
}
