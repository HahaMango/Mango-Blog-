using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Blog.DAO;
using Blog.DAO.Imp;
using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Test.Config;
using System.Threading.Tasks;
using Blog.Models.ArticleModels;

namespace Test.DAOTest
{
    [TestClass]
    public class UserArticleDAOTest
    {

        private readonly DbContextOptions<ArticleContext> contextOptions;

        public UserArticleDAOTest()
        {
            contextOptions = DAOHepler.GetDbContextOptions();
        }

        [TestMethod]
        public void GetArticleById()
        {
            using(var context = new ArticleContext(contextOptions))
            {
                UserArticleDAO userArticleDAO = new UserArticleDAO(context);
                userArticleDAO.AddArticle(new Article
                {
                    Id = 1,
                    PageId = 1,
                });
            }
        }

        [TestMethod]
        public void OutTestData()
        {
            List<Article> articles = new List<Article>();
            for(int i = 0; i < 100; i++)
            {
                Article article = new Article()
                {
                    Id = i,
                    PageId = i
                };
            }
        }

        //97-122
        private string RandomString(int len)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            for(int i = 0; i < len; i++)
            {
                char c = (char)random.Next(97, 122);
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
    }
}
