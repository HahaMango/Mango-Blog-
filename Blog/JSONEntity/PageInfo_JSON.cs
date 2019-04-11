using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.JSONEntity
{
    public class PageInfo_JSON
    {
        public string Page_id { get; set; }
        public string User_id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
        public int Like_Count { get; set; }
        public int View_Count { get; set; }
        public int Comment_Count { get; set; }
        public string Description { get; set; }
        public int Word_Count { get; set; }
        public List<Category_JSON> categories { get; set; }
    }
}
