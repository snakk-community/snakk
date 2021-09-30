//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;

namespace Snakk.API.QueryResult.Dto.Routes.Thread.Comment.List.Services.Get
{
    public class CommentListDto : BasePluginDataDto
    {
        public IEnumerable<ThreadDto> List { get; set; }
    }

    public class ThreadDto : BasePluginDataDto
    {
        public long CommentId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
