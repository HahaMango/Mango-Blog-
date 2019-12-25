/*
 * 对布尔类型的返回值更改为空返回类型，函数出错则直接抛出异常。
 **/

using MangoBlog.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoBlog.Entity
{
    public interface IArticleDao
    {
        Task AddArticleAsync(ArticleInfoModel article,ArticleContentModel articleContentModel);
        Task DeleteArticleById(string id);
        Task<IList<ArticleInfoModel>> GetArticleInfosAsync(int start, int count);
        Task<IList<ArticleInfoModel>> GetArticleInfosAsync();
        Task<ArticleInfoModel> GetArticleInfoAsync(string id);
        Task<ArticleContentModel> GetArticleContentAsync(string id);
        Task UpdateArticleAsync(ArticleInfoModel article,ArticleContentModel articleContentModel);
        Task<int> ArticleCountAsync();
        Task IncViewAsync(string id);
        Task DecIncLikeAsync(string id, bool inc);
    }
}
