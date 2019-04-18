using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;

namespace Blog.DAO.Imp
{
    public class ArticleCategoryDAO : IArticleCategoryDAO<string>
    {

        private readonly ArticleContext _articleContext = null;

        public ArticleCategoryDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddCategory(ArticleCategory articleCategory)
        {
            throw new NotImplementedException();
        }

        public int DeleteCategory(ArticleCategory articleCategory)
        {
            throw new NotImplementedException();
        }

        public List<ArticleCategory> GetArticleCategory(string userid)
        {
            throw new NotImplementedException();
        }

        public int UpdateCategory(ArticleCategory articleCategory)
        {
            throw new NotImplementedException();
        }
    }
}
