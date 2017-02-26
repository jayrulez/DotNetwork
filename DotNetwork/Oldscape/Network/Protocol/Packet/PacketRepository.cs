// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DotNetwork.Oldscape.Network.Protocol.Packet.Encoder;
using DotNetwork.Oldscape.Network.Protocol.Packet.Decoder;

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
        public static readonly Dictionary<Type, object> PACKET_ENCODERS = BuildEncoders();

        /// <summary>
        /// A dictionary of packet decoders.
        /// </summary>
        public static readonly Dictionary<int[], PacketDecoder> PACKET_DECODERS = BuildDecoders();

        /// <summary>
        /// Constructs the packet encoders for the dictionary.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<Type, object> BuildEncoders()
        {
            Dictionary<Type, object> builder = new Dictionary<Type, object>();
            try
            {
                Type[] classes = Assembly.GetExecutingAssembly().GetTypes().Where(a => a.Namespace == $"{Constants.NAMESPACE_PRESENTATION}.Network.Protocol.Packet.Encoder.Impl").ToArray();
                foreach (Type encoder in classes)
                {
                    object @class = Activator.CreateInstance(encoder);
                    Type context = @class.GetType().BaseType.GetGenericArguments().FirstOrDefault();
                    builder.Add(context, @class);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return builder;
        }

        /// <summary>
        /// Constructs the packet decpders for the dictionary.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int[], PacketDecoder> BuildDecoders()
        {
            Dictionary<int[], PacketDecoder> builder = new Dictionary<int[], PacketDecoder>();
            try
            {
                Type[] classes = Assembly.GetExecutingAssembly().GetTypes().Where(a => a.Namespace == $"{Constants.NAMESPACE_PRESENTATION}.Network.Protocol.Packet.Decoder.Impl").ToArray();
                foreach (Type decoder in classes)
                {
                    PacketDecoder @class = Activator.CreateInstance(decoder) as PacketDecoder;
                    builder.Add(@class.GetPacketIds(), @class);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
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

        /// <summary>
        /// Gets a packet decoder for the incoming packet id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PacketDecoder GetPacketDecoder(int id)
        {
            return PACKET_DECODERS.FirstOrDefault(kvp => kvp.Key.Any(i => i == id)).Value;
        }

    }
}
