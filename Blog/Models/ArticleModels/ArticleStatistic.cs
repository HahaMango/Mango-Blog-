using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class ArticleStatistic
    {
        [Key]
        public int Id { get; set; }

        public int PageId { get; set; }

        public int Like { get; set; }

        public int Reads { get; set; }

        public int Comments { get; set; }

        public int WordCount { get; set; }

        public virtual Article Article { get; set; }
    }
}
