using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoBlog.Model
{
    public class CommentModel
    {
        /// <summary>
        /// 评论id
        /// </summary>
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }        
    }
}
