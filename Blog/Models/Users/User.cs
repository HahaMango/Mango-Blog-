﻿using Blog.Models.Article;
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
        public string PassWord { get; set; }
        public Role Role { get; set; }
    }
}
