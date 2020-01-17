using MangoBlog.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangoBlog.Entity.Imp
{
    public class CategoryDao : ICategoryDao
    {
        private readonly MangoBlogDBContext _dBContext = null;

        public CategoryDao(MangoBlogDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AddCategoryAsync(string categoryName)
        {
            if(categoryName == null)
            {
                throw new ArgumentNullException();
            }
            var category = new CategoryEntity
            {
                CategoryName = categoryName
            };
            await _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _dBContext.Categories.Where(c => c.Id == id).SingleOrDefaultAsync();
            if(category == null)
            {
                throw new NotFoundException($"没找到id为：{id}的类别");
            }
            _dBContext.Categories.Remove(category);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IList<string>> GetCategoryAsync()
        {
            var c = await _dBContext.Categories.ToListAsync();
            return c.Select(ce => ce.CategoryName).ToList();
        }

        public async Task<string> GetCategoryByArticleId(string articleId)
        {
            if(articleId == null)
            {
                throw new ArgumentNullException();
            }
            var article = await _dBContext.Articles.Include(c=>c.Category).Where(a => a.Id == int.Parse(articleId)).SingleOrDefaultAsync();
            if(article == null)
            {
                throw new NotFoundException($"没找到id为：{articleId}的文章");
            }
            return article.Category.CategoryName;
        }

        public async Task<string> GetCategoryByIdAsync(int id)
        {
            var ce = await _dBContext.Categories.Where(c => c.Id == id).SingleOrDefaultAsync();
            if(ce == null)
            {
                throw new NotFoundException($"没找到id为：{id}的类别");
            }
            return ce.CategoryName;
        }

        public async Task<bool> IsExistAsync(string categoryName)
        {
            var ce = await _dBContext.Categories.Where(c => c.CategoryName == categoryName).ToListAsync();
            if(ce == null || ce.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
