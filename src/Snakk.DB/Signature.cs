//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Signature")]
    public class Signature
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public string Text { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
