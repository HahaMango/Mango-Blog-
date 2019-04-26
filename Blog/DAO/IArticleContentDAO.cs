using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    interface IArticleContentDAO<ArticleType>
    {
        #region 同步接口
        ArticleContent GetArticleContent(ArticleType articleid);

        int AddContent(ArticleContent articleContent);

        int UpdateContent(ArticleContent articleContent);

        int DeleteContent(ArticleContent articleContent);

        #endregion

        #region 异步接口

        Task<ArticleContent> GetArticleContentAsync(ArticleType articleid);

        Task<int> AddContentAsync(ArticleContent articleContent);

        Task<int> UpdateContentAsync(ArticleContent articleContent);

        Task<int> DeleteContentAsync(ArticleContent articleContent);

        #endregion

    }
}
