using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Article
{
    public class Page
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public string Author { get; set; }
        public int flag { get; set; }
        public PageContent Content { get; set; }
        public List<Comment> Comment { get; set; }
        public User User { get; set; }
    }
}
