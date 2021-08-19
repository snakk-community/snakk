//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Survey")]
    public class Survey
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsClosed { get; set; }
        public bool IsDeleted { get; set; }

        public List<SurveyQuestion> Questions { get; set; } = new List<SurveyQuestion>();
    }
}
