using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.JSONEntity
{
    public class ArticleJSON
    {
        public string Page_id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
        public int Like_Count { get; set; }
        public int Read_Count { get; set; }
        public int Comment_Count { get; set; }
        public string Description { get; set; }
        public int Word_Count { get; set; }
        public bool IsOriginal { get; set; }
        public List<string> categories { get; set; }
        public ArticleContentJSON PageContent { get; set; }
    }
}
