using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public User FollowingUser { get; set; }
        [NotMapped]
        public User FollowedUser { get; set; }
    }
}
