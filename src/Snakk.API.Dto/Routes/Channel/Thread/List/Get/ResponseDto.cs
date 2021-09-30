//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;

namespace Snakk.API.Dto.Routes.Channel.Thread.List.Get
{
    public class ResponseDto
    {
        public List<ResponseThreadDto> List { get; set; }

        public Dictionary<string, object> PluginData { get; set; }
    }

    public class ResponseThreadDto
    {
        public string HashId { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsClosed { get; set; }
        public bool IsPinned { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsSafeForKids { get; set; }

        public Dictionary<string, object> PluginData { get; set; }
    }
}
