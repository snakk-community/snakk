//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Tag")]
    public class Tag
    {
        public long Id { get; set; }
        public string Slug { get; set; }
        
        public string Name { get; set; }

        public string HexColor { get; set; }

        public int? SortWeight { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsDeleted { get; set; }
    }
}
