using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Users
{
    public class Role
    {
        public int Id { get; set; }
        public int UserId { get; set;}
        public int RoleIdentity { get; set; }
        public int Flag { get; set; }
    }
}
