using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class Article
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int PageId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        [Column(TypeName = "varchar(120)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Author { get; set; }

        [Column(TypeName = "varchar(120)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(120)")]
        public string Categories { get; set; }

        public int Like { get; set; }

        public int Reads { get; set; }

        public int Comments { get; set; }

        public int WordCount { get; set; }

        public bool IsOriginal { get; set; }

        [NotMapped]
        public List<Comment> comments { get; set; }
        [NotMapped]
        public ArticleContent PageContent { get; set; }
    }
}
