using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Blog.DAO;
using Blog.DAO.Imp;

namespace Test.Config
{
    public static class DAOHepler
    {
        private static DbContextOptions<ArticleContext> contextOptions;

        static DAOHepler()
        {
            DbContextOptionsBuilder<ArticleContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<ArticleContext>();
            //dbContextOptionsBuilder.UseInMemoryDatabase(databaseName:"blogtest");            
            dbContextOptionsBuilder.UseMySql("server=localhost;database=blogtest;user=root;password=228887");
            contextOptions = dbContextOptionsBuilder.Options;
        }

        public static DbContextOptions<ArticleContext> GetDbContextOptions()
        {
            return contextOptions;
        }
    }
}
