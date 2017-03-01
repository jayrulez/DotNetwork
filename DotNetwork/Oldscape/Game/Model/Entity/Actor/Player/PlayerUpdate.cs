// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Player
{

    /// <summary>
    /// The player update.
    /// </summary>
    sealed class PlayerUpdate
    {

        /// <summary>
        /// Updates a player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static PacketBuilder Update(Player player)
        {
            var buffer = new PacketBuilder();
            var block = new PacketBuilder();

            buffer.SwitchToBitAccess();
            buffer.PutBits(1, 1);
            buffer.PutBits(2, 0);
            WriteUpdateBlocks(player, block);
            buffer.PutBits(8, 0);
            if (block.GetBuffer().ReadableBytes > 0)
            {
                buffer.PutBits(11, 2047);
                buffer.SwitchToByteAccess();
                buffer.GetBuffer().WriteBytes(block.GetBuffer());
            }
            else
                buffer.SwitchToByteAccess();
            return buffer;
        }

        /// <summary>
        /// Writes any pending update blocks.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="block"></param>
        private static void WriteUpdateBlocks(Player player, PacketBuilder block)
        {
            int mask = 0x0;
            foreach (var b in player.GetActorRenderer().GetUpdateBlocks())
            {
                if (b != null)
                    mask |= b.GetMask();
            }

            if (mask >= 0x100)
                mask |= 0x80;

            block.Put(DataType.BYTE, mask);
            if (mask >= 0x100)
                block.Put(DataType.BYTE, mask >> 8);

            foreach (var b in player.GetActorRenderer().GetUpdateBlocks())
            {
                if (b != null)
                    b.EncodeBlock(player, block);
            }
        }

    }
}
