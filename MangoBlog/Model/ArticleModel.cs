using System;
using System.ComponentModel.DataAnnotations;

namespace MangoBlog.Model
{
    public class ArticleModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Describe { get; set; }
        public int Read { get; set; }
        public int Like { get; set; }
        public int Comment { get; set; }
        [Required]
        public string Category { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        public string ContentType { get; set; }

        public ArticleInfoModel ToArticleInfoModel()
        {
            return new ArticleInfoModel
            {
                Id = "0",
                Title = Title,
                Describe = Describe,
                Read = Read,
                Like = Like,
                Comment = Comment,
                Category = Category,
                Date = Date
            };
        }

        public ArticleContentModel ToArticleContentModel()
        {
            return new ArticleContentModel
            {
                Id = "0",
                ArticleId = "0",
                Content = Content,
                ContentType = ContentType
            };
        }
    }
}
