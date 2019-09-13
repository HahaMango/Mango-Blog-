using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;
using Blog.JSONEntity;

namespace Blog.Helper
{
    /// <summary>
    /// 在前端JSON和数据库模型之间的转换类。（数据库已修改，重新检查）
    /// </summary>
    /// 
    [Obsolete]
    public static class JMConvert
    {
        /// <summary>
        /// Article对象JOSN转换到Model
        /// (手动设置userid)
        /// </summary>
        /// <param name="articleJSON"></param>
        /// <returns></returns>
        public static Article ArticleJ2M(ArticleJSON articleJSON)
        {
            Article article = new Article
            {
                PageId =(articleJSON.Page_id !=null)? int.Parse(articleJSON.Page_id):0,
                CreateTime = articleJSON.Create_Time,
                UpdateTime = articleJSON.Update_Time,
                Title = articleJSON.Title,
                Author = articleJSON.Author,
                Description = articleJSON.Description,
                Categories = string.Join(",", articleJSON.categories),
                IsOriginal = articleJSON.IsOriginal
            };
            return article;
        }

        /// <summary>
        /// Article对象Model转换到JSON
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static ArticleJSON ArticleM2J(Article article,ArticleStatistic articleStatistic)
        {
            ArticleJSON articleJSON = new ArticleJSON
            {
                Page_id = article.PageId.ToString(),
                Title = article.Title,
                Author = article.Author,
                Create_Time = article.CreateTime,
                Update_Time = article.UpdateTime,
                Like_Count = articleStatistic.Like,
                Read_Count = articleStatistic.Reads,
                Comment_Count = articleStatistic.Comments,
                Description = article.Description,
                Word_Count = articleStatistic.WordCount,
                IsOriginal = article.IsOriginal,
                categories = article.Categories.Split(',').ToList()
            };
            return articleJSON;
        }

        /// <summary>
        /// Content对象JSON转换到Model
        /// </summary>
        /// <param name="articleContentJSON"></param>
        /// <returns></returns>
        public static ArticleContent ArticleContentJ2M(ArticleContentJSON articleContentJSON)
        {
            ArticleContent articleContent = new ArticleContent
            {
                PageId = int.Parse(articleContentJSON.Page_id),
                Content = articleContentJSON.Content
            };
            return articleContent;
        }

        /// <summary>
        /// Content对象Model转换到JSON
        /// </summary>
        /// <param name="articleContent"></param>
        /// <returns></returns>
        public static ArticleContentJSON ArticleContentM2J(ArticleContent articleContent)
        {
            ArticleContentJSON articleContentJSON = new ArticleContentJSON
            {
                Page_id = articleContent.PageId.ToString(),
                Content = articleContent.Content
            };
            return articleContentJSON;
        }

        /// <summary>
        /// Comment对象JSON转换到Model
        /// （手动设置userid）
        /// </summary>
        /// <param name="commentJSON"></param>
        /// <returns></returns>
        public static Comment CommentJ2M(CommentJSON commentJSON)
        {
            Comment comment = new Comment
            {                
                CommentId = int.Parse(commentJSON.Commend_id),
                //PageId = int.Parse(commentJSON.Page_id),
                CreateTime = commentJSON.CreateTime,
                ReplyComId = int.Parse(commentJSON.Reply.Commend_id),
                IsReply = commentJSON.IsReply,
                Content = commentJSON.Content,
                Like = commentJSON.LikeCount
            };
            return comment;
        }

        /// <summary>
        /// Comment对象Model转换到JSON
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static CommentJSON CommentM2J(Comment comment)
        {
            CommentJSON commentJSON = new CommentJSON
            {
                Commend_id = comment.CommentId.ToString(),
                //Page_id = comment.PageId.ToString(),
                CreateTime = comment.CreateTime,
                Content = comment.Content,
                Reply = null,
                LikeCount = comment.Like,
                IsReply = comment.IsReply
            };
            return commentJSON;
        }

        /// <summary>
        /// Category对象JSON转换到Model
        /// (手动设置userid)
        /// </summary>
        /// <param name="categoryJSON"></param>
        /// <returns></returns>
        public static ArticleCategory CategoryJ2M(CategoryJSON categoryJSON)
        {
            ArticleCategory articleCategory = new ArticleCategory
            {
                DisplayName = categoryJSON.DisplayName,
                ArticleCount = categoryJSON.ArticleCount
            };
            return articleCategory;
        }

        /// <summary>
        /// Category对象Model转换为JSON
        /// </summary>
        /// <param name="articleCategory"></param>
        /// <returns></returns>
        public static CategoryJSON CategoryM2J(ArticleCategory articleCategory)
        {
            CategoryJSON categoryJSON = new CategoryJSON
            {
                DisplayName = articleCategory.DisplayName,
                ArticleCount = articleCategory.ArticleCount
            };
            return categoryJSON;
        }
    }
}
