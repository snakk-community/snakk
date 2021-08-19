//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("SurveyQuestionOption")]
    public class SurveyQuestionOption
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public bool IsDeleted { get; set; }

        public List<SurveyQuestionAnswer> Answers { get; set; } = new List<SurveyQuestionAnswer>();
    }
}
