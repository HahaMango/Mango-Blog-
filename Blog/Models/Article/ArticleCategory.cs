using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Article
{
    public class ArticleCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Identity { get; set; }
        public DateTime AddTime { get; set; }
    }
}
