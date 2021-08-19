using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Vote")]
    public class Vote
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsNegative { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
