using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.JSONEntity
{
    public class CommentJSON
    {
        public string Commend_id { get; set; }
        public string Page_id { get; set; }
        public string UserName { get; set; }
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        public CommentJSON Reply { get; set; } 
        public int LikeCount { get; set; }

        public bool IsReply { get; set; }
    }
}
