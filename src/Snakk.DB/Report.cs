using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("Report")]
    public class Report
    {
        public long Id { get; set; }

        public string Message { get; set; }

        public int ReportTypeId { get; set; }

        public DateTime CreatedUtc { get; set; }

        public List<ReportComment> Comments { get; set; } = new List<ReportComment>();
    }
}
