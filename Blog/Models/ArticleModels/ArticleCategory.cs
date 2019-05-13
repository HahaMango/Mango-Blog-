using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.ArticleModels
{
    public class ArticleCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Userid { get; set; }

        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string DisplayName { get; set; }

        public DateTime AddTime { get; set; }
    }
}
