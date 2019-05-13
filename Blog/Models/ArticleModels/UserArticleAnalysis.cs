using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class UserArticleAnalysis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public int TotalLike { get; set; }

        public int TotalComment { get; set; }

        public int TotalRead { get; set; }

        public int TotalArticle { get; set; }

        public int TotalOriginal { get; set; }
    }
}
