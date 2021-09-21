//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Extensions;
using System.Collections.Generic;

namespace Snakk.API.Helpers
{
    public static class Hook
    {
        public static void Invoke<T>(
            IEnumerable<T> pluginEnumerable,
            System.Action<T> action)
        {
            pluginEnumerable.ForEach(action);
        }
    }
}
