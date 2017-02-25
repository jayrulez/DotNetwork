// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Info;
using DotNetwork.Oldscape.Util.Isaac;

namespace DotNetwork.Oldscape.Network.Protocol.Codec.Login
{

    /// <summary>
    /// The login request.
    /// </summary>
    sealed class LoginRequest
    {

        /// <summary>
        /// The client version.
        /// </summary>
        private readonly int version;

        /// <summary>
        /// The player username.
        /// </summary>
        private readonly string username;

        /// <summary>
        /// The player password.
        /// </summary>
        private readonly string password;

        /// <summary>
        /// The gamepack token.
        /// </summary>
        private readonly string token;

        /// <summary>
        /// The cache crc.
        /// </summary>
        private readonly int[] crc;

        /// <summary>
        /// The isaac engine group.
        /// </summary>
        private readonly IsaacRandGroup isaacGroup;

        /// <summary>
        /// The player machine information.
        /// </summary>
        private readonly MachineInformation machineInformation;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <param name="crc"></param>
        /// <param name="isaacGroup"></param>
        /// <param name="machineInformation"></param>
        public LoginRequest(int version, string username, string password, string token, int[] crc, IsaacRandGroup isaacGroup, MachineInformation machineInformation)
        {
            this.version = version;
            this.username = username;
            this.password = password;
            this.token = token;
            this.crc = crc;
            this.isaacGroup = isaacGroup;
            this.machineInformation = machineInformation;
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns></returns>
        public int GetVersion()
        {
            return version;
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <returns></returns>
        public string GetUsername()
        {
            return username;
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <returns></returns>
        public string GetPassword()
        {
            return password;
        }

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            return token;
        }

        /// <summary>
        /// Gets the crc.
        /// </summary>
        /// <returns></returns>
        public int[] GetCrc()
        {
            return crc;
        }

        /// <summary>
        /// Gets the isaac engine group.
        /// </summary>
        /// <returns></returns>
        public IsaacRandGroup GetIsaacRandGroup()
        {
            return isaacGroup;
        }

        /// <summary>
        /// Gets the machine information.
        /// </summary>
        /// <returns></returns>
        public MachineInformation GetMachineInformation()
        {
            return machineInformation;
        }

    }
}
