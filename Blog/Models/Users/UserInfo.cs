using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Users
{
    public class UserInfo
    {
        public int Id { get; set;}
        public int UserId { get; set; }
        public bool Sex { get; set; }
        public string PhotoPath { get; set; }
        public DateTime BirthDay { get; set; }
        public string Pe { get; set; }
    }
}
