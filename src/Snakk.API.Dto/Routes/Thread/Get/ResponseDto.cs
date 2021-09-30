//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;

namespace Snakk.API.Dto.Routes.Thread.Get
{
    public class ResponseDto : BaseResponseDto
    {
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
