using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class ArticleStatistic
    {
        [Required]
        public int PageId { get; set; }

        public int Like { get; set; }

        public int Reads { get; set; }

        public int Comments { get; set; }

        public int WordCount { get; set; }
    }
}
