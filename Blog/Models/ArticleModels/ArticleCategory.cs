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
        [Column(TypeName = "varchar(12)")]
        public string Userid { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string DisplayName { get; set; }
        public DateTime AddTime { get; set; }
    }
}
