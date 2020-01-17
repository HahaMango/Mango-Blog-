using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoBlog.Entity;

namespace MangoBlog.Service.Imp
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDao _categoryDao = null;

        public CategoryService(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        public async Task AddCategoryAsync(string categoryName)
        {
            if(categoryName == null)
            {
                throw new ArgumentNullException();
            }
            await _categoryDao.AddCategoryAsync(categoryName);
        }

        public async Task<IList<string>> GetCategoriesAsync()
        {
            return await _categoryDao.GetCategoryAsync();
        }

        public async Task<string> GetCategoryByArticleIdAsync(string articleId)
        {
            if(articleId == null)
            {
                throw new NullReferenceException();
            }
            return await _categoryDao.GetCategoryByArticleId(articleId);
        }
    }
}
