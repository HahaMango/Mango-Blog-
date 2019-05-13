using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;
using Blog.Helper;

namespace Blog.DAO
{
    public interface IUserArticleDAO<UserType,ArticleType>
    {
        #region 同步查询接口

        //基本查询   
        Article GetArticleById(UserType userid, ArticleType articleid);
        List<Article> GetArticlesById(UserType userid);
        int DeleteArticle(Article article);
        int UpdateArticle(Article article);
        int AddArticle(Article article);

        //模糊查询和参数查询
        List<Article> GetArticlesBySearch(UserType userid, SearchArgument searchArgument);
        Article GetMostLike(UserType userid);
        Article GetMostRead(UserType userid);
        Article GetMostWord(UserType userid);
        Article GetMostComments(UserType userid);
        int CountLike(UserType userid);
        int CountRead(UserType userid);
        int CountComments(UserType userid);
        List<Article> GetOriginal(UserType userid);

        //排序加分页
        List<Article> GetArticlesById(UserType userid, int page, int count);
        List<Article> GetArticlesBySearch(UserType userid, SearchArgument searchArgument,int page,int count);

        List<Article> GetArticlesSortByDate(UserType userid, int page, int count);
        List<Article> GetArticlesSortByRead(UserType userid, int page, int count);
        List<Article> GetArticlesSortByLike(UserType userid,int page,int count);
        List<Article> GetArticlesSortByWord(UserType userid,int page,int count);
        List<Article> GetArticlesSortByComments(UserType userid,int page,int count);
        List<Article> GetArticlesByOriginal(UserType userid,int page,int count);
        #endregion

        #region 异步查询接口

        Task<Article> GetArticleByIdAsync(UserType userid, ArticleType articleid);
        Task<List<Article>> GetArticlesByIdAsync(UserType userid);
        Task<int> DeleteArticleAsync(Article article);
        Task<int> UpdateArticleAsync(Article article);
        Task<int> AddArticleAsync(Article article);

        //模糊查询和参数查询
        Task<List<Article>> GetArticlesBySearchAsync(UserType userid, SearchArgument searchArgument);
        Task<Article> GetMostLikeAsync(UserType userid);
        Task<Article> GetMostReadAsync(UserType userid);
        Task<Article> GetMostWordAsync(UserType userid);
        Task<Article> GetMostCommentsAsync(UserType userid);
        Task<int> CountLikeAsync(UserType userid);
        Task<int> CountReadAsync(UserType userid);
        Task<int> CountCommentsAsync(UserType userid);
        Task<List<Article>> GetOriginalAsync(UserType userid);

        //排序加分页
        Task<List<Article>> GetArticlesSortByDateAsync(UserType userid, int page, int count);
        Task<List<Article>> GetArticlesSortByReadAsync(UserType userid, int page, int count);
        Task<List<Article>> GetArticlesBySearchAsync(UserType userid, SearchArgument searchArgument,int page,int count);
        Task<List<Article>> GetArticlesSortByLikeAsync(UserType userid, int page, int count);
        Task<List<Article>> GetArticlesSortByWordAsync(UserType userid, int page, int count);
        Task<List<Article>> GetArticlesSortByCommentsAsync(UserType userid, int page, int count);
        Task<List<Article>> GetArticlesByOriginalAsync(UserType userid, int page, int count);

        #endregion
    }
}
