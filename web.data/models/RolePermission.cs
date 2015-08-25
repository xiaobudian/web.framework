using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web.data.models
{
    public class RolePermission
    {
        public int Id { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int PermissionId { get; set; }
    }
}