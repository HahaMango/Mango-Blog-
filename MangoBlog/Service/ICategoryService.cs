using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoBlog.Service
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(string categoryName);
        Task<IList<string>> GetCategoriesAsync();
        Task<string> GetCategoryByArticleIdAsync(string articleId);
    }
}
