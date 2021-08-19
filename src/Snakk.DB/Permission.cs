using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Permission")]
    public class Permission
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public bool IsDeleted { get; set; }
    }
}
