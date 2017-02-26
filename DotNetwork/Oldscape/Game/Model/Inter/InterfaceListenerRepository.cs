// Copyright (c) DotNetwork. All rights reserved.
// Licensed under the MIT license. See LICENSE file for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetwork.Oldscape.Game.Model.Inter
{

    /// <summary>
    /// A repository of interface listeners.
    /// </summary>
    sealed class InterfaceListenerRepository
    {

        /// <summary>
        /// A dictionary of interface listeners.
        /// </summary>
        public static readonly Dictionary<int, InterfaceListener> INTERFACE_LISTENERS = BuildListeners();

        /// <summary>
        /// Builds the interface listeners.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, InterfaceListener> BuildListeners()
        {
            Dictionary<int, InterfaceListener> builder = new Dictionary<int, InterfaceListener>();
            try
            {
                Type[] classes = Assembly.GetExecutingAssembly().GetTypes().Where(a => a.Namespace == $"{Constants.NAMESPACE_PRESENTATION}.Game.Model.Inter.Impl").ToArray();
                foreach (Type listener in classes)
                {
                    var @class = Activator.CreateInstance(listener) as InterfaceListener;
                    builder.Add(@class.GetInterfaceId(), @class);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return builder;
        }

        /// <summary>
        /// Gets a interface listener for a interface id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static InterfaceListener GetInterfaceListener(int id)
        {
            if (INTERFACE_LISTENERS.ContainsKey(id))
                return INTERFACE_LISTENERS[id];
            return INTERFACE_LISTENERS[-1];
        }

    }
}
