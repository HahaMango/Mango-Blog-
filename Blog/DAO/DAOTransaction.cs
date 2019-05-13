using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Blog.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Blog.DAO
{
    public class DAOTransaction
    {
        private readonly ArticleContext _articleContext = null;

        public DAOTransaction(ArticleContext articleContext)
        {
            this._articleContext = articleContext;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _articleContext.Database.BeginTransaction();
        }
    }
}
