//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("AccessGroup")]
    public class AccessGroup
    {
        public long AccessGroupId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserAccessGroup> UserAccessGroups { get; set; } = new List<UserAccessGroup>();
        public List<ChannelAccessGroup> ChannelAccessGroups { get; set; } = new List<ChannelAccessGroup>();
    }
}
