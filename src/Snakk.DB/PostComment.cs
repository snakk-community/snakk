using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("PostComment")]
    public class PostComment : Comment
    {
        public bool IsWarning { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
