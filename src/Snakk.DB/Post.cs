//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Post")]
    public class Post
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsClosed { get; set; }
        public bool IsPinned { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsSafeForKids { get; set; }

        public List<PostComment> Comments { get; set; } = new List<PostComment>();
        public List<PostBan> Bans { get; set; } = new List<PostBan>();
        public List<PostReport> Reports { get; set; } = new List<PostReport>();
        public List<PostSubscription> Subscriptions { get; set; } = new List<PostSubscription>();
        public List<PostSurvey> Surveys { get; set; } = new List<PostSurvey>();
        public List<PostLastView> LastViews { get; set; } = new List<PostLastView>();
    }
}
