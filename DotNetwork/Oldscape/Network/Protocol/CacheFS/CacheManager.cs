// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using OpenRSS.Cache;
using System;

namespace DotNetwork.Oldscape.Network.Protocol.CacheFS
{

    /// <summary>
    /// The cache manager.
    /// </summary>
    sealed class CacheManager
    {

        /// <summary>
        /// The cache.
        /// </summary>
        private static Cache cache;

        /// <summary>
        /// The checksum table.
        /// </summary>
        private static ChecksumTable checksumTable;

        /// <summary>
        /// The checksum buffer.
        /// </summary>
        private static byte[] checksumBuffer;

        /// <summary>
        /// Loads the cache.
        /// </summary>
        public static void Load()
        {
            cache = new Cache(FileStore.Open(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/cache/"));
            checksumTable = cache.CreateChecksumTable();
            checksumBuffer = new Container(Container.COMPRESSION_NONE, checksumTable.Encode()).Encode().array();
            Console.WriteLine("Loaded " + cache.GetTypeCount() + " cache indexes.");
        }

        /// <summary>
        /// Gets the cache.
        /// </summary>
        /// <returns></returns>
        public static Cache GetCache()
        {
            return cache;
        }

        /// <summary>
        /// Gets the checksum table.
        /// </summary>
        /// <returns></returns>
        public static ChecksumTable GetChecksumTable()
        {
            return checksumTable;
        }

        /// <summary>
        /// Gets the checksum buffer.
        /// </summary>
        /// <returns></returns>
        public static byte[] GetChecksumBuffer()
        {
            return checksumBuffer;
        }

    }
}
