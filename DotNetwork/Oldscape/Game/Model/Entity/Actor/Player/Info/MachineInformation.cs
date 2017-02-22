// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using DotNetty.Buffers;
using DotNetwork.Oldscape.Util.Buf;

namespace DotNetwork.Oldscape.Game.Model.Entity.Actor.Player.Info
{

    /// <summary>
    /// The machine information of the player.
    /// </summary>
    sealed class MachineInformation
    {

        /// <summary>
        /// The architecture type.
        /// </summary>
        private readonly int architecture;

        /// <summary>
        /// The operating system build.
        /// </summary>
        private readonly int build;

        /// <summary>
        /// The vendor.
        /// </summary>
        private readonly int vendor;

        /// <summary>
        /// <true>If the cpu is x64.</true>
        /// <false>If the cpu is x32.</false>
        /// </summary>
        private readonly bool x64;

        /// <summary>
        /// Constructs a new object.
        /// </summary>
        /// <param name="architecture"></param>
        /// <param name="x64"></param>
        /// <param name="build"></param>
        /// <param name="vendor"></param>
        public MachineInformation(int architecture, bool x64, int build, int vendor)
        {
            this.architecture = architecture;
            this.x64 = x64;
            this.build = build;
            this.vendor = vendor;
        }

        /// <summary>
        /// Gets the architecture.
        /// </summary>
        /// <returns></returns>
        public int GetArchitecture()
        {
            return architecture;
        }

        /// <summary>
        /// Gets the build.
        /// </summary>
        /// <returns></returns>
        public int GetBuild()
        {
            return build;
        }

        /// <summary>
        /// Gets the vendor.
        /// </summary>
        /// <returns></returns>
        public int GetVendor()
        {
            return vendor;
        }

        /// <summary>
        /// Gets the cpu bit.
        /// </summary>
        /// <returns></returns>
        public bool isX64()
        {
            return x64;
        }

        /// <summary>
        /// Decodes the machine information straight from login.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static MachineInformation Decode(IByteBuffer buffer)
        {
            buffer.ReadByte();
            int architecture = buffer.ReadByte();
            bool x64 = buffer.ReadBoolean();
            int build = buffer.ReadByte();
            int vendor = buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            buffer.ReadByte();
            IByteBufferExtensions.ReadJagString(buffer);
            IByteBufferExtensions.ReadJagString(buffer);
            IByteBufferExtensions.ReadJagString(buffer);
            IByteBufferExtensions.ReadJagString(buffer);
            buffer.ReadByte();
            buffer.ReadUnsignedShort();
            IByteBufferExtensions.ReadJagString(buffer);
            IByteBufferExtensions.ReadJagString(buffer);
            buffer.ReadByte();
            buffer.ReadByte();
            return new MachineInformation(architecture, x64, build, vendor);
        }

    }
}
