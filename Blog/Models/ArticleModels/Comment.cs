using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Blog.Models.ArticleModels
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string CommentId { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string PageId { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string UserId { get; set; }
        
        public DateTime CreateTime { get; set; }
        public int ReplyComId { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public bool IsReply { get; set; }
    }
}
