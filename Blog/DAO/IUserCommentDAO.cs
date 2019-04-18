using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    interface IUserCommentDAO<ArticleType,UserType>
    {
        List<Comment> GetCommentsByArticleId(ArticleType articleid);
        int AddComment(Comment comment);
        int DeleteComment(Comment comment);
        int UpdateComment(Comment comment);

        List<Comment> GetCommentsByLike(UserType userid);
    }
}
