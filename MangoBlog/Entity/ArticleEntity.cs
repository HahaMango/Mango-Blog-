using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoBlog.Entity
{
    public class ArticleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Describe { get; set; }
        public int Read { get; set; }
        public int Like { get; set; }
        public int Comment { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
    }
}
