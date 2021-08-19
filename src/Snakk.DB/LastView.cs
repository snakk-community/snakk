using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("LastView")]
    public class LastView
    {
        public long Id { get; set; }
        
        public DateTime LastViewUtc { get; set; }
    }
}
