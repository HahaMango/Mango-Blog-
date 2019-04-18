using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;

namespace Blog.DAO.Imp
{
    public class ArticleContentDAO : IArticleContentDAO<string>
    {

        private readonly ArticleContext _articleContext = null;

        public ArticleContentDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddContent(ArticleContent articleContent)
        {
            throw new NotImplementedException();
        }

        public int DeleteContent(ArticleContent articleContent)
        {
            throw new NotImplementedException();
        }

        public ArticleContent GetArticleContent(string articleid)
        {
            throw new NotImplementedException();
        }

        public int UpdateContent(ArticleContent articleContent)
        {
            throw new NotImplementedException();
        }
    }
}
