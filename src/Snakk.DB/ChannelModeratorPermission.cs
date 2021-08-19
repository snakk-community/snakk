using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("ChannelModeratorPermission")]
    public class ChannelModeratorPermission : Permission
    {
        public int ChannelModeratorPermissionTypeId { get; set; }
    }
}
