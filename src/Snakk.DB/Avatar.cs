using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Avatar")]
    public class Avatar
    {
        public long Id { get; set; }

        public DateTime CreatedUtc { get; set; }

        public long FileSizeInBytes { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
