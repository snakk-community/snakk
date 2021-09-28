//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Comment")]
    public class Comment
    {
        public long CommentId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsDeleted { get; set; }

        public List<CommentReport> Reports { get; set; } = new List<CommentReport>();
        public List<Vote> Votes { get; set; } = new List<Vote>();
    }
}
