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
        Task<bool> IncViewActionAsync(string id);
        Task<bool> DecIncLikeActionAsync(string id, bool inc);
        Task<int> ArticleCountAsync();
        Task<bool> UpdateArticleAsync(ArticleInfoModel article);
        Task<bool> AddArticleAsync(ArticleInfoModel article,ArticleContentModel articleContent);
        Task<bool> DeleteArticleAsync(string id);
    }
}
