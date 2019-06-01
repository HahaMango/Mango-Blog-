using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    public interface IUserArticleAnalysisDAO<UserType>
    {
        #region 同步接口

        int AddArticleAnalysis(UserArticleAnalysis userArticleAnalysis);
        int DeleteArticleAnalysis(UserType userid);
        int UpdateArticleAnalysis(UserArticleAnalysis userArticleAnalysis);
        UserArticleAnalysis GetArticleAnalysis(UserType userid);

        int IncTotalLike(UserType userid);
        int IncTotalComment(UserType userid);
        int IncTotalRead(UserType userid);
        int IncTotalArticle(UserType userid);
        int IncTotalOriginal(UserType userid);

        #endregion


        #region 异步接口

        Task<int> AddArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis);
        Task<int> DeleteArticleAnalysisAsync(UserType userid);
        Task<int> UpdateArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis);
        Task<UserArticleAnalysis> GetArticleAnalysisAsync(UserType userid);

        Task<int> IncTotalLikeAsync(UserType userid);
        Task<int> IncTotalCommentAsync(UserType userid);
        Task<int> IncTotalReadAsync(UserType userid);
        Task<int> IncTotalArticleAsync(UserType userid);
        Task<int> IncTotalOriginalAsync(UserType userid);
        #endregion
    }
}
