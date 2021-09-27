//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("ThreadComment")]
    public class ThreadComment : Comment
    {
        public bool IsWarning { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
