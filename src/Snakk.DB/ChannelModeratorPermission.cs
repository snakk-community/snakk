//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("ChannelModeratorPermission")]
    public class ChannelModeratorPermission : Permission
    {
        public int ChannelModeratorPermissionTypeId { get; set; }
    }
}
