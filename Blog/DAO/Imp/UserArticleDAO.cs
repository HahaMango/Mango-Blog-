using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

using Blog.Models;

namespace Blog.DAO.Imp
{
    public class UserArticleDAO : IUserArticleDao<string, string>
    {

        private readonly ArticleContext _articleContext = null;

        public UserArticleDAO(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public int AddArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public int DeleteArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public Article GetArticleById(string userid, string articleid)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByAuthor(string userid, string author)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByCategory(string userid, string category)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesById(string userid)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByMostComments(string userid, int comments)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByMostLike(string userid, int like)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByMostRead(string userid, int read)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByMostWord(string userid, int word)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByTime(string userid, DateTime being, DateTime end)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesByTitle(string userid, string title)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesIsOriginal(string userid)
        {
            throw new NotImplementedException();
        }

        public int UpdateArticle(Article article)
        {
            throw new NotImplementedException();
        }
    }
}
