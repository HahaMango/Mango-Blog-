using Blog.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool Sex { get; set; }
        public string PhotoPath { get; set; }
        public DateTime BirthDay { get; set; }
        public string Pe { get; set; }
        public Role Role { get; set; }
    }
}
