using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Helper;
using Blog.JSONEntity;

namespace Blog.Service
{
    public interface IArticleBaseService<UserIdType,ArticleIdType>
    {
        Resultion AddArticle(UserIdType userid,Article_JSON article);
        Resultion DeleteArticle(UserIdType userid, ArticleIdType articleId);
        Resultion UpdateArticle(UserIdType userId, Article_JSON article);
        PageContent_JSON GetContent(UserIdType userId, ArticleIdType articleId);
        Article_JSON GetArticleInfo(UserIdType userId, ArticleIdType articleId);
        Article_JSON GetArticleWithContent(UserIdType userId, ArticleIdType articleId);
        List<Article_JSON> GetArticles(UserIdType userId);
        List<Article_JSON> GetArticlesWithPara(UserIdType userid, SearchPara searchPara);
    }
}
