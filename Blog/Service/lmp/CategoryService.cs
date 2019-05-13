using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Helper;
using Blog.JSONEntity;

namespace Blog.Service.lmp
{
    public class CategoryService : ICategoryService<string>
    {
        public Resultion Add(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public Task<Resultion> AddAsync(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public Resultion Delete(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public Task<Resultion> DeleteAsync(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public List<CategoryJSON> GetCategories(string id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryJSON> GetCategories(string id, int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryJSON>> GetCategoriesAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryJSON>> GetCategoriesAsync(string id, int count)
        {
            throw new NotImplementedException();
        }

        public CategoryJSON GetCategory(string userid, int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryJSON> GetCategoryAsync(string userid, int id)
        {
            throw new NotImplementedException();
        }

        public Resultion Replace(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }

        public Task<Resultion> ReplaceAsync(string userid, CategoryJSON category)
        {
            throw new NotImplementedException();
        }
    }
}
