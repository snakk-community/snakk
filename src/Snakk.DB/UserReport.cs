//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("UserReport")]
    public class UserReport : Report
    {
        public User User { get; set; }
        public long UserId { get; set; }
        
        public User ReportedUser { get; set; }
        public long ReportedUserId { get; set; }
    }
}
