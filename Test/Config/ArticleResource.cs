using Blog.Models;
using Blog.Models.ArticleModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Config
{
    public class ArticleResource
    {
        #region 测试数据定义
        private int[] ids =
        {
            
        };

        #endregion

        public void AddArticle(ArticleContext articleContext,int being,int end)
        {
            articleContext.Articles.AddRange(CreateArticleByRange(being, end));
        }

        private List<Article> CreateArticleByRange(int being,int end)
        {
            List<Article> articles = new List<Article>();
            for(int i = being; i < end; i++)
            {
                Article article = new Article()
                {
                    Id = i
                };
                articles.Add(article);
            }
            return articles;
            
        }
    }
}
