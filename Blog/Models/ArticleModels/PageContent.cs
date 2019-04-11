using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class PageContent
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public string Content { get; set; }
        public Page Page { get; set; }
    }
}
