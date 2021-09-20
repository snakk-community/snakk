//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

namespace Snakk.API.PluginFramework
{
    public interface IParseRequestData
    {
        void ParseRequestData(object pluginData);
    }
}
