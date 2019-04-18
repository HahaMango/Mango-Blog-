using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    interface IArticleCategoryDAO<UserType>
    {
        List<ArticleCategory> GetArticleCategory(UserType userid);
        int AddCategory(ArticleCategory articleCategory);
        int DeleteCategory(ArticleCategory articleCategory);
        int UpdateCategory(ArticleCategory articleCategory);
    }
}
