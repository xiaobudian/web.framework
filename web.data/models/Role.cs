using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web.data.models
{
    public class Role
    {
        public Role()
        {
            this.Permission = new HashSet<Permission>();
            this.User = new HashSet<User>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Permission> Permission { get; set; }
        public virtual ICollection<User> User { get; set; }

    }
}