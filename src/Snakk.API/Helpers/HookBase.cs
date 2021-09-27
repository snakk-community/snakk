//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Extensions;
using Snakk.API.PluginFramework;
using System.Collections.Generic;

namespace Snakk.API.Helpers
{
    public static class HookBase
    {
        public static void Invoke<T>(
            IEnumerable<T> pluginEnumerable,
            Dictionary<string, object> pluginRequestDataDictionary,
            Dictionary<string, dynamic> pluginDataDictionary,
            System.Action<T, object, dynamic> action)
        {
            pluginEnumerable.ForEach(plugin => {
                var id = ((IPlugin)plugin).GetId();

                var pluginRequestData = pluginRequestDataDictionary.ContainsKey(id)
                    ? pluginRequestDataDictionary[id]
                    : null;

                var pluginData = pluginDataDictionary.ContainsKey(id)
                    ? pluginDataDictionary[id]
                    : null;

                action(
                    plugin,
                    pluginRequestData,
                    pluginData);

                if (pluginData != null)
                {
                    if (pluginDataDictionary.ContainsKey(id))
                    {
                        pluginDataDictionary[id] = pluginData;
                    }

                    else
                    {
                        pluginDataDictionary.Add(id, pluginData);
                    }
                }
            });
        }
    }
}
