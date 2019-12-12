using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoBlog.Model
{
    public class ArticleInfoModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Describe { get; set; }
        public int Read { get; set; }
        public int Like { get; set;}
        public int Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
