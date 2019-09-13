using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Helper;
using Blog.JSONEntity;
using Blog.DAO;

namespace Blog.Service.lmp
{
    /// <summary>
    /// 对文章分类进行增删查改
    /// </summary>
    public class CategoryService : ICategoryService<string>
    {
        private readonly IArticleCategoryDAO<int> _articleCategoryDAO;

        public CategoryService(IArticleCategoryDAO<int> articleCategoryDAO)
        {
            this._articleCategoryDAO = articleCategoryDAO;
        }

        public virtual Resultion Add(string userid, CategoryJSON category)
        {
            return null;
        }

        public virtual Task<Resultion> AddAsync(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public virtual Resultion Delete(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public virtual Task<Resultion> DeleteAsync(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public virtual List<CategoryJSON> GetCategories(string id)
        {
            throw new NotImplementedException();
        }

        public virtual List<CategoryJSON> GetCategories(string id, int count)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<CategoryJSON>> GetCategoriesAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<CategoryJSON>> GetCategoriesAsync(string id, int count)
        {
            throw new NotImplementedException();
        }

        public virtual CategoryJSON GetCategory(string userid, int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<CategoryJSON> GetCategoryAsync(string userid, int id)
        {
            throw new NotImplementedException();
        }

        public virtual Resultion Replace(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public virtual Task<Resultion> ReplaceAsync(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }
    }
}
