//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;

namespace Snakk.API.Dto.Routes.Thread.Comment.List.Get
{
    public class ResponseDto
    {
        public List<ResponseCommentDto> List { get; set; }

        public Dictionary<string, object> PluginData { get; set; }
    }

    public class ResponseCommentDto
    {
        public string HashId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedUtc { get; set; }

        public Dictionary<string, object> PluginData { get; set; }
    }
}
