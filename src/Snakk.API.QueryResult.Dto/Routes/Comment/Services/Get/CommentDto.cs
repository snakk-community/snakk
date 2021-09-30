//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;

namespace Snakk.API.QueryResult.Dto.Routes.Comment.Services.Get
{
    public class CommentDto : BasePluginDataDto
    {
        public long CommentId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
