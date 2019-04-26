using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    interface IArticleCategoryDAO<UserType>
    {
        #region 同步方法
        List<ArticleCategory> GetArticleCategory(UserType userid);
        int AddCategory(ArticleCategory articleCategory);
        int DeleteCategory(ArticleCategory articleCategory);
        int UpdateCategory(ArticleCategory articleCategory);
        #endregion

        #region 异步方法

        Task<List<ArticleCategory>> GetArticleCategoryAsync(UserType userid);
        Task<int> AddCategoryAsync(ArticleCategory articleCategory);
        Task<int> DeleteCategoryAsync(ArticleCategory articleCategory);
        Task<int> UpdateCategoryAsync(ArticleCategory articleCategory);

        #endregion
    }
}
