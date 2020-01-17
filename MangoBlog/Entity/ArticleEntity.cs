using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangoBlog.Entity
{
    public class ArticleEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Describe { get; set; }
        public int Read { get; set; }
        public int Like { get; set; }
        public int Comment { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Date { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public IList<CommentEntity> Comments { get; set; }

        public ArticleContentEnttiy ArticleContent { get; set; }
    }
}
