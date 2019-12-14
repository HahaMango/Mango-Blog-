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
        Task<ArticleContentModel> GetArticleContentAsync(string id);
        Task<bool> LikeActionAsync(string id);
        Task<int> ArticleCountAsync();
    }
}
