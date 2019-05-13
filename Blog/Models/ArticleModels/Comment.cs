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

        [Required]
        public int CommentId { get; set; }

        [Required]
        public int PageId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }
        
        public DateTime CreateTime { get; set; }

        public int ReplyComId { get; set; }

        public string Content { get; set; }

        public int Like { get; set; }

        public bool IsReply { get; set; }
    }
}
