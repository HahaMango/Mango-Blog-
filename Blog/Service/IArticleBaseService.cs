using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Helper;
using Blog.JSONEntity;

namespace Blog.Service
{
    /// <summary>
    /// 
    /// 文章服务接口
    /// 
    /// </summary>
    /// <typeparam name="UserNameType"></typeparam>
    /// <typeparam name="ArticleIdType"></typeparam>
    public interface IArticleBaseService<UserNameType,ArticleIdType>
    {
        #region 同步方法

        //添加文章
        Resultion AddArticle(UserNameType username,ArticleJSON article);

        //删除文章
        Resultion DeleteArticle(UserNameType username, ArticleJSON article);

        //更新文章
        Resultion UpdateArticle(UserNameType username, ArticleJSON article);

        //获取文章具体内容
        ArticleContentJSON GetContent(UserNameType username, ArticleIdType articleId);

        //获取文章的简要信息
        ArticleJSON GetArticleInfo(UserNameType username, ArticleIdType articleId);

        //获取文章的所有信息
        ArticleJSON GetArticleDetail(UserNameType username, ArticleIdType articleId);

        //获取对应用户的文章列表,提供分页
        List<ArticleJSON> GetArticles(UserNameType username,int page,int count);

        //根据具体的请求参数获取用户的文章列表，提供分页
        List<ArticleJSON> GetArticlesWithPara(UserNameType username, SearchArgument searchPara,int page,int count);

        //对用户文章按阅读量排名，提供分页
        List<ArticleJSON> GetArticleSortByRead(UserNameType username,int page,int count);

        #endregion

        #region 异步方法

        Task<Resultion> AddArticleAsync(UserNameType username, ArticleJSON article);

        Task<Resultion> DeleteArticleAsync(UserNameType username, ArticleJSON article);

        Task<Resultion> UpdateArticleAsync(UserNameType username, ArticleJSON article);

        Task<ArticleContentJSON> GetContentAsync(UserNameType username, ArticleIdType articleId);

        Task<ArticleJSON> GetArticleInfoAsync(UserNameType username, ArticleIdType articleId);

        Task<ArticleJSON> GetArticleDetailAsync(UserNameType username, ArticleIdType articleId);

        Task<List<ArticleJSON>> GetArticlesAsync(UserNameType username,int page,int count);

        Task<List<ArticleJSON>> GetArticlesWithParaAsync(UserNameType username, SearchArgument searchPara,int page,int count);

        Task<List<ArticleJSON>> GetArticleSortByReadAsync(UserNameType username,int page,int count);

        #endregion
    }
}
