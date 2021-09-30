//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;

namespace Snakk.API.QueryResult.Dto.Routes.Channel.Thread.List.Services.Get
{
    public class ThreadListDto : BasePluginDataDto
    {
        public IEnumerable<ThreadDto> List { get; set; }
    }

    public class ThreadDto : BasePluginDataDto
    {
        public long ThreadId { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsClosed { get; set; }
        public bool IsPinned { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsSafeForKids { get; set; }
    }
}
