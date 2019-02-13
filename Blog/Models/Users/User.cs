using Blog.Models.Article;
using Blog.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Blog.Models.Users
{
    public class User: IdentityUser<int>
    {       
        public override int Id { get; set; }
        public int UserId { get; set; }
        public override string UserName { get; set; }
        public string PassWord { get; set; }
        public Role Role { get; set; }
    }
}
