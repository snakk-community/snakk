using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("SurveyQuestion")]
    public class SurveyQuestion
    {
        public long Id { get; set; }
        public string Text { get; set; }

        public int SurveyQuestionTypeId { get; set; }

        public bool IsDeleted { get; set; }

        public List<SurveyQuestionOption> Options { get; set; } = new List<SurveyQuestionOption>();
    }
}
