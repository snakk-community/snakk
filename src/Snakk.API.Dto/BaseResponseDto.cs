//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Collections.Generic;

namespace Snakk.API.Dto
{
    public class BaseResponseDto
    {
        public Dictionary<string, object> PluginData { get; set; }
    }
}
