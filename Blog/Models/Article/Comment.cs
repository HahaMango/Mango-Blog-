using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.Users;

namespace Blog.Models.Article
{
    public class Comment
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public DateTime CreateTime { get; set; }
        public int ComUserId { get; set; }
        public int ReplyUserId { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }

        public Page Page { get; set; }
        [NotMapped]
        public User ComUser { get; set; }
        [NotMapped]
        public User ReplyUser { get; set; }
    }
}
