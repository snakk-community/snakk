using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snakk.DB
{
    [Table("AdministratorPermission")]
    public class AdministratorPermission : Permission
    {
        public int AdministratorPermissionTypeId { get; set; }
    }
}
