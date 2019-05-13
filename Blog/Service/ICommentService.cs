using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.JSONEntity;
using Blog.Helper;

namespace Blog.Service
{
    public interface ICommentService<UserType,ArticleType,CommentType>
    {
        #region 同步方法

        CommentJSON GetCommentById(UserType userid,CommentType commentid);

        List<CommentJSON> GetComments(UserType userid);

        Resultion DeleteComment(UserType userid, CommentType commentid);

        Resultion UpdateComment(UserType userid, CommentType commentid,CommentJSON comment);

        Resultion AddCommentToArticle(UserType userid, ArticleType articleid,CommentJSON comment);

        #endregion

        #region 异步方法

        Task<CommentJSON> GetCommentByIdAsync(UserType userid, CommentType commentid);

        Task<List<CommentJSON>> GetCommentsAsync(UserType userid);

        Task<Resultion> DeleteCommentAsync(UserType userid, CommentType commentid);

        Task<Resultion> UpdateCommentAsync(UserType userid, CommentType commentid, CommentJSON comment);

        Task<Resultion> AddCommentToArticleAsync(UserType userid, ArticleType articleid, CommentJSON comment);

        #endregion
    }
}
