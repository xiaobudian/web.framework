using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.data.models
{
    public class webEntities : DbContext
    {
        public webEntities()
        {
            Database.CreateIfNotExists();
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

    }
}
