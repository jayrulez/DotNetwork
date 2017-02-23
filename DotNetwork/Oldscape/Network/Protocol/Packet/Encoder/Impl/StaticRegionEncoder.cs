// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player;
using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Network.Protocol.Packet.Encoder.Impl
{

    /// <summary>
    /// The static region encoder.
    /// </summary>
    sealed class StaticRegionEncoder : PacketEncoder<StaticRegionContext>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public StaticRegionEncoder() : base(133, PacketType.VARIABLE_SHORT) { }

        /// <summary>
        /// Encodes the packet.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="context"></param>
        public override void Encode(StaticRegionContext context)
        {

            int chunkX = context.GetPosition().GetCentralSectorX();
            int chunkY = context.GetPosition().GetCentralSectorY();
            int localX = context.GetPosition().GetLocalX();
            int localY = context.GetPosition().GetLocalY();

            builder.Put(DataType.SHORT, DataOrder.LITTLE, DataTransformation.ADD, localX);

            bool force = false;
            if ((48 == chunkX / 8 || chunkX / 8 == 49) && chunkY / 8 == 48)
                force = true;

            if (48 == chunkX / 8 && chunkY / 8 == 148)
                force = true;

            for (int x = (chunkX - 6) / 8; x <= (6 + chunkX) / 8; ++x)
            {
                for (int y = (chunkY - 6) / 8; y <= (6 + chunkY) / 8; ++y)
                {
                    if (!force || y != 49 && 149 != y && 147 != y && x != 50 && (x != 49 || y != 47))
                    {
                        builder.Put(DataType.INT, 0);
                        builder.Put(DataType.INT, 0);
                        builder.Put(DataType.INT, 0);
                        builder.Put(DataType.INT, 0);
                    }
                }
            }

            builder.Put(DataType.SHORT, DataOrder.LITTLE, localY);
            builder.Put(DataType.BYTE, DataTransformation.NEGATE, context.GetPosition().GetHeight());
            builder.Put(DataType.SHORT, DataTransformation.ADD, chunkX);
            builder.Put(DataType.SHORT, DataOrder.LITTLE, DataTransformation.ADD, chunkY);

        }
    }
}
