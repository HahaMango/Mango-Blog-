using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoBlog.Entity
{
    public interface ICategoryDao
    {
        Task AddCategoryAsync(string categoryName);
        Task DeleteCategoryAsync(int id);
        Task<string> GetCategoryByIdAsync(int id);
        Task<IList<string>> GetCategoryAsync();
        Task<bool> IsExistAsync(string categoryName);
        Task<string> GetCategoryByArticleId(string articleId);
    }
}
