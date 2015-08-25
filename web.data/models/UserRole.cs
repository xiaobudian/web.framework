using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.data.models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}