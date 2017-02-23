// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotNetwork.Oldscape.Network.Protocol.Packet.Encoder;

namespace DotNetwork.Oldscape.Network.Protocol.Packet
{

    /// <summary>
    /// A repository to hold server packets.
    /// </summary>
    sealed class PacketRepository
    {

        /// <summary>
        /// A dictionary of packet encoders.
        /// </summary>
        public static readonly Dictionary<Type, object> PACKET_ENCODERS = ConstructEncoders();

        /// <summary>
        /// Constructs the packet encoders for the dictionary.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Type, object> ConstructEncoders()
        {
            Dictionary<Type, object> builder = new Dictionary<Type, object>();
            Type[] classes = Assembly.GetExecutingAssembly().GetTypes().Where(a => a.Namespace == $"{Constants.NAMESPACE_PRESENTATION}.Network.Protocol.Packet.Encoder.Impl").ToArray();
            foreach (Type encoder in classes)
            {
                object @class = Activator.CreateInstance(encoder);
                Type context = @class.GetType().BaseType.GetGenericArguments().FirstOrDefault();
                builder.Add(context, @class);
            }

            return builder;
        }

        /// <summary>
        /// Gets a packet encoder based on the used packet context.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static object GetPacketEncoder(PacketContext context)
        {
            object encoder;
            if (PACKET_ENCODERS.TryGetValue(context.GetType(), out encoder))
                return encoder;

            return null;
        }

    }
}
