//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Ban")]
    public class Ban
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsPermanent { get; set; }
        public bool IsShadow { get; set; }

        public DateTime? FromUtc { get; set; }
        public DateTime? ToUtc { get; set; }
    }
}
