using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangoBlog.Entity
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string UserName { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Comment { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }
    }
}
