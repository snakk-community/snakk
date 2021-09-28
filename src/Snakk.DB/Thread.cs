//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Thread")]
    public class Thread
    {
        public long ThreadId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsClosed { get; set; }
        public bool IsPinned { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAnonymous { get; set; }
        public bool IsSafeForKids { get; set; }

        public List<ThreadComment> Comments { get; set; } = new List<ThreadComment>();
        public List<ThreadBan> Bans { get; set; } = new List<ThreadBan>();
        public List<ThreadReport> Reports { get; set; } = new List<ThreadReport>();
        public List<ThreadSubscription> Subscriptions { get; set; } = new List<ThreadSubscription>();
        public List<ThreadSurvey> Surveys { get; set; } = new List<ThreadSurvey>();
        public List<ThreadLastView> LastViews { get; set; } = new List<ThreadLastView>();
    }
}
