using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAO.Imp
{
    public class ArticleCategoryDAO : IArticleCategoryDAO<int>
    {

        private readonly ArticleContext _articleContext = null;

        public ArticleCategoryDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddCategory(ArticleCategory articleCategory)
        {
            try
            {
                _articleContext.ArticleCategories.Add(articleCategory);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddCategoryAsync(ArticleCategory articleCategory)
        {
            try
            {
                _articleContext.ArticleCategories.Add(articleCategory);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public int DeleteCategory(ArticleCategory articleCategory)
        {
            try
            {
                ArticleCategory temp = _articleContext.ArticleCategories.Where(ac => ac.Id == articleCategory.Id).Single();

                _articleContext.ArticleCategories.Remove(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteCategoryAsync(ArticleCategory articleCategory)
        {
            try
            {
                ArticleCategory temp = _articleContext.ArticleCategories.Where(ac => ac.Id == articleCategory.Id).Single();

                _articleContext.ArticleCategories.Remove(temp);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public List<ArticleCategory> GetArticleCategory(int userid)
        {
            try
            {
                return _articleContext.ArticleCategories
                    .Where(ac => ac.Userid == userid)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ArticleCategory>> GetArticleCategoryAsync(int userid)
        {
            try
            {
                return await _articleContext.ArticleCategories
                    .Where(ac => ac.Userid == userid)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateCategory(ArticleCategory articleCategory)
        {
            try
            {
                ArticleCategory temp = _articleContext.ArticleCategories
                    .Where(ac => ac.Id == articleCategory.Id)
                    .Single();

                temp.DisplayName = articleCategory.DisplayName;                

                _articleContext.ArticleCategories.Update(temp);

                return _articleContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateCategoryAsync(ArticleCategory articleCategory)
        {
            try
            {
                ArticleCategory temp = _articleContext.ArticleCategories
                    .Where(ac => ac.Id == articleCategory.Id)
                    .Single();

                temp.DisplayName = articleCategory.DisplayName;

                _articleContext.ArticleCategories.Update(temp);

                return await _articleContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
