//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;

namespace Snakk.API.QueryResult.Dto.Routes.Channel.Services.Get
{
    public class ChannelDto : BasePluginDataDto
    {
        public long ChannelId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public bool AllowAnonymous { get; set; }
        public bool AllowAgeConfirmation { get; set; }

        public bool IsPublic { get; set; }
        public bool IsPinned { get; set; }
        public bool AllowAllModerators { get; set; }

        public int? SortWeight { get; set; }

        public DateTime CreatedUtc { get; set; }
    }
}
