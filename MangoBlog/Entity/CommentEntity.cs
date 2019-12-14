using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoBlog.Entity
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
