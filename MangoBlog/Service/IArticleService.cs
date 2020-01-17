using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;

namespace MangoBlog.Service
{
    public interface IArticleService
    {
        Task<IList<ArticleInfoModel>> GetArticleInfosAsync(int startCount,int count);
        Task<IList<ArticleInfoModel>> GetArticleInfosAsync();
        Task<ArticleInfoModel> GetArticleByIdAsync(string id);
        Task<ArticleContentModel> GetArticleContentByIdAsync(string id);
        Task IncViewActionAsync(string id);
        Task DecIncLikeActionAsync(string id, bool inc);
        Task<int> ArticleCountAsync();
        Task UpdateArticleAsync(ArticleInfoModel article,ArticleContentModel articleContentModel);
        Task AddArticleAsync(ArticleInfoModel article,ArticleContentModel articleContent);
        Task DeleteArticleAsync(string id);
    }
}
