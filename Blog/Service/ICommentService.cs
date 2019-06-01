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

        CommentJSON GetCommentById(UserType username, CommentType commentid);

        List<CommentJSON> GetComments(UserType username, int page,int count);

        List<CommentJSON> GetCommentsByArticle(ArticleType articleid,int page,int count);

        Resultion DeleteComment(UserType username, CommentType commentid);

        Resultion UpdateComment(UserType username, CommentType commentid,CommentJSON comment);

        Resultion AddCommentToArticle(UserType ususername, ArticleType articleid,CommentJSON comment);

        Resultion LikeComment(CommentType commentid);

        #endregion

        #region 异步方法

        Task<CommentJSON> GetCommentByIdAsync(UserType username, CommentType commentid);

        Task<List<CommentJSON>> GetCommentsAsync(UserType username, int page,int count);

        Task<List<CommentJSON>> GetCommentsByArticleAsync(ArticleType articleid,int page,int count);

        Task<Resultion> DeleteCommentAsync(UserType username, CommentType commentid);

        Task<Resultion> UpdateCommentAsync(UserType username, CommentType commentid, CommentJSON comment);

        Task<Resultion> AddCommentToArticleAsync(UserType username, ArticleType articleid, CommentJSON comment);

        Task<Resultion> LikeCommentAsync(CommentType commentid);

        #endregion
    }
}
