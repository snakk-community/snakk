//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Channel")]
    public class Channel
    {
        public long Id { get; set; }
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

        public List<Thread> Threads { get; set; } = new List<Thread>();
        public List<ChannelBan> Bans { get; set; } = new List<ChannelBan>();
        public List<ChannelTag> Tags { get; set; } = new List<ChannelTag>();
        public List<ChannelAvatar> Avatars { get; set; } = new List<ChannelAvatar>();
        public List<ChannelReport> Reports { get; set; } = new List<ChannelReport>();
        public List<ChannelRule> Rules { get; set; } = new List<ChannelRule>();
        public List<ChannelLastView> LastViews { get; set; } = new List<ChannelLastView>();
        public List<ChannelSubscription> Subscriptions { get; set; } = new List<ChannelSubscription>();
        public List<ChannelModeratorPermission> ModeratorPermissions { get; set; } = new List<ChannelModeratorPermission>();
    }
}
