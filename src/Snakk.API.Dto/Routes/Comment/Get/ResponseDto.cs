//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;

namespace Snakk.API.Dto.Routes.Comment.Get
{
    public class ResponseDto : BaseResponseDto
    {
        public string Text { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
