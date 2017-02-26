// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Network.Protocol.Packet.Context.Impl;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Manager
{

    /// <summary>
    /// The interface manager.
    /// </summary>
    sealed class InterfaceManager
    {

        /// <summary>
        /// The default root interface id.
        /// </summary>
        public const int DEFAULT_ROOT_INTERFACE = 548;

        /// <summary>
        /// The default game window id.
        /// </summary>
        public const int WINDOW_ID = 9;

        /// <summary>
        /// The default tabs.
        /// </summary>
        private readonly int[] DEFAULT_TABS = new int[] { 593, 320, 274, 149, 387, 271, 218, 589, 429, 432, 182, 261, 216, 239 };

        /// <summary>
        /// The player.
        /// </summary>
        private readonly Player player;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public InterfaceManager(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Sends the player lobby.
        /// </summary>
        public void SendLobby()
        {
            SendRootInterface(165);
        }

        /// <summary>
        /// Sends the default login interface information.
        /// </summary>
        public void SendLoginDefaults()
        {
            SendRootInterface(DEFAULT_ROOT_INTERFACE);
            player.SendPacket(new InterfaceContext(DEFAULT_ROOT_INTERFACE, 18, 162, true));
            player.SendPacket(new InterfaceContext(DEFAULT_ROOT_INTERFACE, 8, 160, true));
            SendDefaultTabs();
        }

        /// <summary>
        /// Sends the default tabs.
        /// </summary>
        public void SendDefaultTabs()
        {
            for (int index = 60; index < (60 + DEFAULT_TABS.Length); index++)
                player.SendPacket(new InterfaceContext(DEFAULT_ROOT_INTERFACE, index, DEFAULT_TABS[index - 60], true));
        }

        /// <summary>
        /// Sends an interface.
        /// </summary>
        /// <param name="id"></param>
        public void SendInterface(int id)
        {
            player.SendPacket(new InterfaceContext(DEFAULT_ROOT_INTERFACE, WINDOW_ID, id, false));
        }

        /// <summary>
        /// Sends a root interface.
        /// </summary>
        /// <param name="id"></param>
        public void SendRootInterface(int id)
        {
            player.SendPacket(new RootInterfaceContext(id));
        }

    }
}
