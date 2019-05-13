using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.JSONEntity;
using Blog.Helper;

namespace Blog.Service
{
    public interface ICategoryService<UserNameType>
    {
        #region 同步方法
        Resultion Add(UserNameType userid,CategoryJSON category);

        Resultion Replace(UserNameType userid,CategoryJSON category);

        Resultion Delete(UserNameType userid,CategoryJSON category);

        List<CategoryJSON> GetCategories(UserNameType id);

        List<CategoryJSON> GetCategories(UserNameType id, int count);

        CategoryJSON GetCategory(UserNameType userid, int id);

        #endregion

        #region 异步方法

        Task<Resultion> AddAsync(UserNameType userid, CategoryJSON category);

        Task<Resultion> ReplaceAsync(UserNameType userid, CategoryJSON category);

        Task<Resultion> DeleteAsync(UserNameType userid, CategoryJSON category);

        Task<List<CategoryJSON>> GetCategoriesAsync(UserNameType id);

        Task<List<CategoryJSON>> GetCategoriesAsync(UserNameType id, int count);

        Task<CategoryJSON> GetCategoryAsync(UserNameType userid, int id);

        #endregion
    }
}
