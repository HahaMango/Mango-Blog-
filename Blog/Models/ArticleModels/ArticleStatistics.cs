using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class ArticleStatistics
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public int Like { get; set; }
        public int Reads { get; set; }
        public int Comments { get; set; }
    }
}
