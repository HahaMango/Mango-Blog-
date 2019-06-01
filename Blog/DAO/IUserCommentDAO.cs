using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    public interface IUserCommentDAO<ArticleType,UserType,CommentId>
    {
        #region 同步接口
        /// <summary>
        ///     返回文章的评论，并且按时间排序
        ///     同步方法
        /// </summary>
        /// <param name="articleid"></param>
        /// <returns></returns>
        List<Comment> GetCommentsByArticleId(ArticleType articleid,int page,int count);

        List<Comment> GetCommentsByUserid(UserType userid,int page,int count);

        Comment GetCommentById(CommentId commentId);
        
        int AddComment(Comment comment);

        int DeleteComment(CommentId commentid);

        int UpdateComment(Comment comment);

        List<Comment> GetCommentsSortByLike(UserType userid,int page,int count);

        int IncLike(CommentId commentId);

        #endregion

        #region 异步接口

        /// <summary>
        ///     返回文章的评论，并且按时间排序
        ///     异步方法
        /// </summary>
        /// <param name="articleid"></param>
        /// <returns></returns>
        Task<List<Comment>> GetCommentsByArticleIdAsync(ArticleType articleid,int page,int count);

        Task<List<Comment>> GetCommentsByUseridAsync(UserType userid,int page,int count);

        Task<Comment> GetCommentByIdAsync(CommentId commentId);

        Task<int> AddCommentAsync(Comment comment);

        Task<int> DeleteCommentAsync(CommentId commentid);

        Task<int> UpdateCommentAsync(Comment comment);

        Task<List<Comment>> GetCommentsSortByLikeAsync(UserType userid,int page,int count);

        Task<int> IncLikeAsync(CommentId commentId);

        #endregion
    }
}
