using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Entity;
using MangoBlog.Model;

namespace MangoBlog.Helper
{
    public static class ModelEntityHelper
    {
        public static ArticleEntity ArticleM2E(ArticleInfoModel articleInfoModel)
        {
            if(articleInfoModel == null)
            {
                throw new NullReferenceException();
            }
            return new ArticleEntity
            {
                Id = (articleInfoModel.Id != null) ? int.Parse(articleInfoModel.Id) : 0,
                Title = articleInfoModel.Title,
                Describe = articleInfoModel.Describe,
                Read = articleInfoModel.Read,
                Like = articleInfoModel.Like,
                Comment = articleInfoModel.Comment,
                Date = articleInfoModel.Date
            };
        }

        public static ArticleInfoModel ArticleE2M(ArticleEntity articleEntity)
        {
            if(articleEntity == null)
            {
                throw new NullReferenceException();
            }
            return new ArticleInfoModel
            {
                Id = articleEntity.Id.ToString(),
                Title = articleEntity.Title,
                Describe = articleEntity.Describe,
                Read = articleEntity.Read,
                Like = articleEntity.Like,
                Comment = articleEntity.Comment,
                Date = articleEntity.Date,
                Category = (articleEntity.Category != null) ? articleEntity.Category.CategoryName : ""
            };
        }

        public static ArticleContentEnttiy ContentM2E(ArticleContentModel articleContentModel)
        {
            if(articleContentModel == null)
            {
                throw new NullReferenceException();
            }
            return new ArticleContentEnttiy
            {
                Id = (articleContentModel.Id != null)? int.Parse(articleContentModel.Id):0,
                Content = articleContentModel.Content,
                ContentType = articleContentModel.ContentType,
                ArticleId = (articleContentModel.ArticleId != null) ? int.Parse(articleContentModel.ArticleId) : 0,
            };
        }

        public static ArticleContentModel ContentE2M(ArticleContentEnttiy articleContentEnttiy)
        {
            if(articleContentEnttiy == null)
            {
                throw new NullReferenceException();
            }
            return new ArticleContentModel
            {
                Id = articleContentEnttiy.Id.ToString(),
                Content = articleContentEnttiy.Content,
                ContentType = articleContentEnttiy.ContentType,
                ArticleId = articleContentEnttiy.ArticleId.ToString()
            };
        }

        public static CommentEntity CommentM2E(CommentModel commentModel)
        {
            if(commentModel == null)
            {
                throw new NullReferenceException();
            }
            return new CommentEntity
            {
                UserName = commentModel.UserName,
                Comment = commentModel.Comment,
            };
        }

        public static CommentModel CommentE2M(CommentEntity commentEntity)
        {
            if(commentEntity == null)
            {
                throw new NullReferenceException();
            }
            return new CommentModel
            {
                Id = commentEntity.Id.ToString(),
                UserName = commentEntity.UserName,
                Comment = commentEntity.Comment,
                Date = commentEntity.Date
            };
        }
    }
}
