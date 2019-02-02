using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Users
{
    public class Relation
    {
        public int Id { get; set; }
        public int FollowingId { get; set; }
        public int FollowedId { get; set; }
        public int Flag { get; set; }
    }
}
