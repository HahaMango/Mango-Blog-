using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class ArticleContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //唯一
        [Column(TypeName = "varchar(12)")]
        public string PageContentId { get; set; }
        //唯一
        [Column(TypeName = "varchar(12)")]
        public string PageId { get; set; }
        [Column(TypeName = "longtext")]
        public string Content { get; set; }
    }
}
