//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;

namespace Snakk.API.QueryResult.Dto.Routes.User.Services.Get
{
    public class UserDto : BasePluginDataDto
    {
        public long UserId { get; set; }

        public string Username { get; set; }
        public string DisplayName { get; set; }

        public int TimeZoneId { get; set; }

        public string About { get; set; }

        public bool IsAdministrator { get; set; }

        public DateTime CreatedUtc { get; set; }

        public long? AvatarId { get; set; }
        public string SignatureText { get; set; }
    }
}
