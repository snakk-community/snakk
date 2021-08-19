using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("SubscriptionNotification")]
    public class SubscriptionNotification
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public int NotificationTypeId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
