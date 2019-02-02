using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Users
{
    public class UserStatistics
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdate { get; set; }
        public int NumberOfLogin { get; set; }

    }
}
