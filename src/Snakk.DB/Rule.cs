//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Rule")]
    public class Rule
    {
        public long RuleId { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }

        public int Number { get; set; }

        public bool IsGlobal { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsDeleted { get; set; }
    }
}
