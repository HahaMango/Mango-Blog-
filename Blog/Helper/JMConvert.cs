using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;
using Blog.JSONEntity;

namespace Blog.Helper
{
    /// <summary>
    /// 在前端JSON和数据库模型之间的转换类。
    /// </summary>
    public static class JMConvert
    {
        /// <summary>
        /// Article对象JOSN转换到Model
        /// </summary>
        /// <param name="articleJSON"></param>
        /// <returns></returns>
        public static Article ArticleJ2M(ArticleJSON articleJSON)
        {
            Article article = new Article
            {
                PageId = int.Parse(articleJSON.Page_id),
                UserId = articleJSON.UserName.GetHashCode(),
                UserName = articleJSON.UserName,
                CreateTime = articleJSON.Create_Time,
                UpdateTime = articleJSON.Update_Time,
                Title = articleJSON.Title,
                Author = articleJSON.Author,
                Description = articleJSON.Description,
                Categories = string.Join(",", articleJSON.categories),
                Like = articleJSON.Like_Count,
                Reads = articleJSON.Read_Count,
                Comments = articleJSON.Comment_Count,
                WordCount = articleJSON.Word_Count,
                IsOriginal = articleJSON.IsOriginal
            };
            return article;
        }

        /// <summary>
        /// Article对象Model转换到JSON
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static ArticleJSON ArticleM2J(Article article)
        {
            ArticleJSON articleJSON = new ArticleJSON
            {
                Page_id = article.PageId.ToString(),
                UserName = article.UserName,
                Title = article.Title,
                Author = article.Author,
                Create_Time = article.CreateTime,
                Update_Time = article.UpdateTime,
                Like_Count = article.Like,
                Read_Count = article.Reads,
                Comment_Count = article.Comments,
                Description = article.Description,
                Word_Count = article.WordCount,
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
        /// </summary>
        /// <param name="commentJSON"></param>
        /// <returns></returns>
        public static Comment CommentJ2M(CommentJSON commentJSON)
        {
            Comment comment = new Comment
            {
                UserId = commentJSON.UserName.GetHashCode(),
                UserName = commentJSON.UserName,
                CommentId = int.Parse(commentJSON.Commend_id),
                PageId = int.Parse(commentJSON.Page_id),
                CreateTime = commentJSON.CreateTime,
                ReplyComId = int.Parse(commentJSON.Reply2id),
                IsReply = commentJSON.IsReply,
                Content = commentJSON.Content,
                Like = commentJSON.LikeCount
            };
            return comment;
        }

        /// <summary>
        /// Category对象JSON转换到Model
        /// </summary>
        /// <param name="categoryJSON"></param>
        /// <returns></returns>
        public static ArticleCategory CategoryJ2M(CategoryJSON categoryJSON)
        {
            ArticleCategory articleCategory = new ArticleCategory
            {
                Userid = categoryJSON.UserName.GetHashCode(),
                UserName = categoryJSON.UserName,
                DisplayName = categoryJSON.DisplayName                
            };
            return articleCategory;
        }

        public static CategoryJSON CategoryM2J(ArticleCategory articleCategory)
        {
            CategoryJSON categoryJSON = new CategoryJSON
            {
                UserName = articleCategory.UserName,
                DisplayName = articleCategory.DisplayName
            };
            return categoryJSON;
        }
    }
}
