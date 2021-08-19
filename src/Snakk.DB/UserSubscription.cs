//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("UserSubscription")]
    public class UserSubscription : Subscription
    {
        public User SubscribeToUser { get; set; }
        public long SubscribeToUserId { get; set; }
    }
}
