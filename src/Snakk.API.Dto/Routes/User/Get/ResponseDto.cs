//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;

namespace Snakk.API.Dto.Routes.User.Get
{
    public class ResponseDto : BaseResponseDto
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public int TimeZoneId { get; set; }
        public string About { get; set; }
        public bool IsAdministrator { get; set; }
        public DateTime CreatedUtc { get; set; }
        public string AvatarHashId { get; set; }
        public string SignatureText { get; set; }
    }
}
