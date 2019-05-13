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
        int DeleteArticleAnalysis(UserArticleAnalysis userArticleAnalysis);
        int UpdateArticleAnalysis(UserArticleAnalysis userArticleAnalysis);
        UserArticleAnalysis GetArticleAnalysis(UserType userid);

        #endregion


        #region 异步接口

        Task<int> AddArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis);
        Task<int> DeleteArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis);
        Task<int> UpdateArticleAnalysisAsync(UserArticleAnalysis userArticleAnalysis);
        Task<UserArticleAnalysis> GetArticleAnalysisAsync(UserType userid);

        #endregion
    }
}
