using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    interface IUserArticleDao<UserType,ArticleType>
    {
        
        Article GetArticleById(UserType userid, ArticleType articleid);
        List<Article> GetArticlesById(UserType userid);
        int DeleteArticle(Article article);
        int UpdateArticle(Article article);
        int AddArticle(Article article);
        
        List<Article> GetArticlesByTitle(UserType userid,string title);
        List<Article> GetArticlesByTime(UserType userid,DateTime being, DateTime end);
        List<Article> GetArticlesByAuthor(UserType userid, string author);
        List<Article> GetArticlesByCategory(UserType userid, string category);
        List<Article> GetArticlesByMostLike(UserType userid, int like);
        List<Article> GetArticlesByMostRead(UserType userid, int read);
        List<Article> GetArticlesByMostWord(UserType userid, int word);
        List<Article> GetArticlesByMostComments(UserType userid, int comments);
        List<Article> GetArticlesIsOriginal(UserType userid);
    }
}
