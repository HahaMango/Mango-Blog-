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

        public async Task<bool> AddCategoryAsync(string categoryName)
        {
            if(categoryName == null)
            {
                throw new NullReferenceException();
            }
            int changRow = 0;
            CategoryEntity categoryEntity = new CategoryEntity
            {
                CategoryName = categoryName
            };
            try
            {
                await _dBContext.Categories.AddAsync(categoryEntity);
                changRow = await _dBContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            return (changRow > 0) ? true : false;
        }

        public async Task<bool> DeleteCategoryAsync(string categoryName)
        {
            if(categoryName == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var category = await _dBContext.Categories.Where(c => c.CategoryName == categoryName).SingleOrDefaultAsync();
                _dBContext.Categories.Remove(category);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _dBContext.Categories.Where(c => c.Id == id).SingleOrDefaultAsync();
                _dBContext.Categories.Remove(category);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> IsExist(string categoryName)
        {
            if(categoryName == null)
            {
                throw new NullReferenceException();
            }
            try
            {
                var c = await _dBContext.Categories.Where(cn => cn.CategoryName == categoryName).SingleOrDefaultAsync();
                if (c != null)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public async Task<string> GetCategoryByIdAsync(int id)
        {
            CategoryEntity cn = null;
            try
            {
                cn = await _dBContext.Categories.Where(c => c.Id == id).SingleOrDefaultAsync();
            }
            catch
            {
                throw;
            }
            return cn.CategoryName;
        }
    }
}
