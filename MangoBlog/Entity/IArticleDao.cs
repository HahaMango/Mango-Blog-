using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Model;

namespace MangoBlog.Entity
{
    public interface IArticleDao
    {
        Task<bool> AddArticleAsync(ArticleInfoModel article);
        Task<bool> AddArticleContentAsync(ArticleContentModel articleContent);
        Task<bool> DeleteArticleAsync(ArticleInfoModel article);
        Task<bool> DeleteArticleById(string id);
        Task<IList<ArticleInfoModel>> GetArticleInfosAsync(int start, int count);
        Task<IList<ArticleInfoModel>> GetArticleInfosAsync();
        Task<ArticleInfoModel> GetArticleInfoAsync(string id);
        Task<ArticleContentModel> GetArticleContentAsync(string id);
        Task<bool> UpdateArticleAsync(ArticleInfoModel article);
        Task<bool> UpdateArticleContentAsync(ArticleContentModel articleContent);
        Task<int> ArticleCountAsync();
    }
}
