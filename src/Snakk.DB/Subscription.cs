using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Subscription")]
    public class Subscription
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsPermanent { get; set; }

        public DateTime? FromUtc { get; set; }
        public DateTime? ToUtc { get; set; }

        public List<SubscriptionNotification> Notifications { get; set; } = new List<SubscriptionNotification>();
    }
}
