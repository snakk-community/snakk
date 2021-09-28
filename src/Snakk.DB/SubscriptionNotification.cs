//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("SubscriptionNotification")]
    public class SubscriptionNotification
    {
        public long SubscriptionNotificationId { get; set; }

        public DateTime CreatedUtc { get; set; }

        public int NotificationTypeId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
