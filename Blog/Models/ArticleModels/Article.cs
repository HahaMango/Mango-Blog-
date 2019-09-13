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

        public bool IsOriginal { get; set; }

        public virtual ArticleStatistic ArticleStatistic { get; set; }
    }
}
