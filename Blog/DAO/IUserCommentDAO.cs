using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    public interface IUserCommentDAO<ArticleType,UserType>
    {
        #region 同步接口

        List<Comment> GetCommentsByArticleId(ArticleType articleid);
        
        int AddComment(Comment comment);

        int DeleteComment(Comment comment);

        int UpdateComment(Comment comment);

        List<Comment> GetCommentsSortByLike(UserType userid);

        List<Comment> GetCommentsSortByTime(ArticleType articleid);

        #endregion

        #region 异步接口

        Task<List<Comment>> GetCommentsByArticleIdAsync(ArticleType articleid);

        Task<int> AddCommentAsync(Comment comment);

        Task<int> DeleteCommentAsync(Comment comment);

        Task<int> UpdateCommentAsync(Comment comment);

        Task<List<Comment>> GetCommentsSortByLikeAsync(UserType userid);

        Task<List<Comment>> GetCommentsSortByTimeAsync(ArticleType articleid);

        #endregion
    }
}
