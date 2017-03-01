// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Update.Encoder;
using DotNetwork.Oldscape.Game.Model.Entity.Actor.Update.Reference;
using DotNetwork.Oldscape.Network.Protocol.Packet;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Block
{

    /// <summary>
    /// The appearance block.
    /// </summary>
    sealed class AppearanceBlock : UpdateBlock<Player>
    {

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        public AppearanceBlock() : base(6, 0x1) { }

        /// <summary>
        /// Encodes the block.
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="builder"></param>
        public override void EncodeBlock(Player actor, PacketBuilder builder)
        {
            byte[] data = GetAppearanceData(actor, actor.GetAppearanceManager().GetAppearance());
            builder.Put(DataType.BYTE, DataTransformation.NEGATE, data.Length);
            builder.PutBytesReverse(data);
        }

        /// <summary>
        /// Gets the appearance data of a specified appearance for a player.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="appearance"></param>
        /// <returns></returns>
        private byte[] GetAppearanceData(Player player, Appearance appearance)
        {
            PacketBuilder builder = new PacketBuilder();
            builder.Put(DataType.BYTE, (int)appearance.GetGender());
            builder.Put(DataType.BYTE, -1);
            builder.Put(DataType.BYTE, -1);
            for (int slot = 0; slot < 4; slot++)
                builder.Put(DataType.BYTE, 0);
            builder.Put(DataType.SHORT, 0x100 + appearance.GetStyles()[2]);// Chest
            builder.Put(DataType.BYTE, 0);// Shield
            builder.Put(DataType.SHORT, 0x100 + appearance.GetStyles()[3]);// Arms
            builder.Put(DataType.SHORT, 0x100 + appearance.GetStyles()[5]);// Legs
            builder.Put(DataType.SHORT, 0x100 + appearance.GetStyles()[0]);// Hat
            builder.Put(DataType.SHORT, 0x100 + appearance.GetStyles()[4]);// Hands
            builder.Put(DataType.SHORT, 0x100 + appearance.GetStyles()[6]);// Feet
            builder.Put(DataType.SHORT, 0x100 + appearance.GetStyles()[1]);// Beard/Boobs
            foreach (int color in appearance.GetColors())
                builder.Put(DataType.BYTE, color);
            builder.Put(DataType.SHORT, 0x328); // stand
            builder.Put(DataType.SHORT, 0x337); // stand turn
            builder.Put(DataType.SHORT, 0x333); // walk
            builder.Put(DataType.SHORT, 0x334); // turn 180
            builder.Put(DataType.SHORT, 0x335); // turn 90 cw
            builder.Put(DataType.SHORT, 0x336); // turn 90 ccw
            builder.Put(DataType.SHORT, 0x338); // run
            builder.PutString("Jordan");
            builder.Put(DataType.BYTE, 126);
            builder.Put(DataType.SHORT, 500);
            builder.Put(DataType.BYTE, 0);

            byte[] data = new byte[builder.GetBuffer().WriterIndex];
            Array.Copy(builder.GetBuffer().Array, 0, data, 0, data.Length);

            return data;
        }

    }
}
