using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models.ArticleModels;

namespace Blog.DAO
{
    interface IArticleContentDAO<ArticleType>
    {
        ArticleContent GetArticleContent(ArticleType articleid);
        int AddContent(ArticleContent articleContent);
        int UpdateContent(ArticleContent articleContent);
        int DeleteContent(ArticleContent articleContent);
    }
}
