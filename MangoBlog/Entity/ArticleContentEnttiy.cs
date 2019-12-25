using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangoBlog.Entity
{
    public class ArticleContentEnttiy
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "longtext")]
        public string Content { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ContentType { get; set; }

        [ForeignKey("ArticleEntity")]
        public int ArticleId { get; set; }
        public ArticleEntity ArticleEntity { get; set; }
    }
}
