//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

namespace Snakk.API.QueryResult.Dto.Routes.Comment.Services.Get
{
    public class CommentDto : BasePluginDataDto
    {
        public long Id { get; set; }
        public string Text { get; set; }
    }
}
