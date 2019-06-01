using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    public interface IArticleStatisticDAO<ArticleType>
    {
        #region 同步接口

        int AddArticleStatistic(ArticleStatistic articleStatistic);

        int DeleteArticleStatistic(ArticleType articleid);

        ArticleStatistic GetArticleStatistic(ArticleType articleid);

        Dictionary<ArticleType, ArticleStatistic> GetArticleStatistics(ArticleType[] articleids);

        int IncLike(ArticleType articleid);

        int IncComment(ArticleType articleid);

        int IncRead(ArticleType articleid);

        #endregion

        #region 异步接口

        Task<int> AddArticleStatisticAsync(ArticleStatistic articleStatistic);

        Task<int> DeleteArticleStatisticAsync(ArticleType articleid);

        Task<ArticleStatistic> GetArticleStatisticAsync(ArticleType articleid);

        Task<Dictionary<ArticleType, ArticleStatistic>> GetArticleStatisticsAsync(ArticleType[] articleids);

        Task<int> IncLikeAsync(ArticleType articleid);

        Task<int> IncCommentAsync(ArticleType articleid);

        Task<int> IncReadAsync(ArticleType articleid);

        #endregion
    }
}
